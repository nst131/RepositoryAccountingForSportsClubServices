using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;
using System;

namespace ServiceAccountingBL
{
    public static class ServiceRegistrationBL
    {
        public static void RegistrationBL(this IServiceCollection services)
        {
            services.AddScoped<IAggregatorClientBL, AggregatorClientBL>();
            services.AddScoped<IClientCrudBL, ClientCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientCrudBL>(() => serviceProvider.GetRequiredService<IClientCrudBL>()));
            services.AddScoped<IClientValidator<CreateClientDtoBL>, CreateClientValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IClientValidator<CreateClientDtoBL>>(() => serviceProvider.GetRequiredService<IClientValidator<CreateClientDtoBL>>()));
            services.AddScoped<IClientValidator<UpdateClientDtoBL>, UpdateClientValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IClientValidator<UpdateClientDtoBL>>(() => serviceProvider.GetRequiredService<IClientValidator<UpdateClientDtoBL>>()));
        }
    }
}
