using Microsoft.Extensions.DependencyInjection;

namespace ServiceAccountingDA.Context
{
    public static class ServiceRegistrationDA
    {
        public static void RegistrationDA(this IServiceCollection services)
        {
            services.AddDbContext<ServiceAccountingContext>();
            services.AddScoped<IServiceAccountingContext, ServiceAccountingContext>();
        }
    }
}
