﻿using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingDA.Context;

namespace ServiceAccountingDA
{
    public static class ServiceRegistrationDA
    {
        public static void AddRegistrationDA(this IServiceCollection services)
        {
            services.AddDbContext<ServiceAccountingContext>();
            services.AddScoped<IServiceAccountingContext, ServiceAccountingContext>();
        }
    }
}
