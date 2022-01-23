using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServiceAccountingBL;
using ServiceAccountingDA;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.HandlerMiddleware;

namespace ServiceAccountingUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceAccountingUI", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddRegistrationBL();
            services.AddRegistrationDA();

            services.AddMvc().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                        ValidateLifetime = true
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(option =>
            {
                option.AddPolicy(PolicyService.AllAccess, policy =>
                    policy.RequireRole(Roles.Administrator, Roles.User, Roles.Trainer, Roles.Responsible)
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                option.AddPolicy(PolicyService.Responsible, policy =>
                    policy.RequireRole(Roles.Administrator, Roles.Responsible)
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                option.AddPolicy(PolicyService.Trainer, policy =>
                    policy.RequireRole(Roles.Administrator, Roles.Trainer)
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                option.AddPolicy(PolicyService.User, policy =>
                    policy.RequireRole(Roles.Administrator, Roles.User)
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                option.AddPolicy(PolicyService.Admin, policy =>
                    policy.RequireRole(Roles.Administrator)
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceAccountingUI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
