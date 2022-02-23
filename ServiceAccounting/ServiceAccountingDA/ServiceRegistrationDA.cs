using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingDA.Context;

namespace ServiceAccountingDA
{
    public static class ServiceRegistrationDA
    {
        public static void AddRegistrationDA(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ServiceAccountingContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IServiceAccountingContext, ServiceAccountingContext>();
        }
    }
}
