using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;

namespace ServiceAccountingBL
{
    public static class ServiceRegistrationBL
    {
        public static void RegistrationBL(this IServiceCollection services)
        {
            services.AddScoped<IAggregatorClientBL, AggregatorClientBL>();
            services.AddScoped<IClientCrudBL, ClientCrudBL>();
            services.AddScoped<IClientValidator<CreateClientDtoBL>, CreateClientValidatorBL>();
        }
    }
}
