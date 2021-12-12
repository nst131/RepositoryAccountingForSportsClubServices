using Microsoft.Extensions.DependencyInjection;

namespace ServiceAccountingDA.Context
{
    public static class ServiceRegistrationDA
    {
        public static void RegistrationDL(this IServiceCollection services)
        {
            services.AddScoped<ServiceAccountingContextFactory>();
            services.AddScoped<IServiceAccountingContext, ServiceAccountingContext>();
        }
    }
}
