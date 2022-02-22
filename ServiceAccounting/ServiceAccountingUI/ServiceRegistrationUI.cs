using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;
using ServiceAccountingUI.Redis;

namespace ServiceAccountingUI
{
    public static class ServiceRegistrationUI
    {
        public static void AddRegistrationUI(this IServiceCollection service)
        {
            service.AddScoped<IRedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL>, RedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL>>();
            service.AddScoped<IRedisAddOrUpdateElement<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL>, RedisAddOrUpdateElement<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL>>();
        }
    }
}
