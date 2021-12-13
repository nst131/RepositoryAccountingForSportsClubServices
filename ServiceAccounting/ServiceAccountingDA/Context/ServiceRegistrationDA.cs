using Microsoft.Extensions.DependencyInjection;

namespace ServiceAccountingDA.Context
{
    public static class ServiceRegistrationDA
    {
        public static void RegistrationDA(this IServiceCollection services)
        {
            //new ServiceAccountingContextFactory().CreateDbContext(new string[0]);
            services.AddDbContext<ServiceAccountingContext>();
            services.AddScoped<IServiceAccountingContext, ServiceAccountingContext>();
        }
    }
}
