using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using RedisLibrary;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;

namespace ServiceAccountingUI
{
    public static class ServiceRegistrationRedis
    {
        public static void AddRegistrationRedis(this IServiceCollection service, DistributedCacheEntryOptions options)
        {
            service.AddScoped<IRedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL>,
                RedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL>>(x => new RedisGetElements<ResponseGetSubscriptionDtoUI, ISubscriptionFetchersBL>(x, options));
            service.AddScoped<IModifierElementsInRedis<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL>,
                ModifierElementsInRedis<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL>>(x => new ModifierElementsInRedis<ResponseGetSubscriptionDtoUI, ISubscriptionCrudBL>(x, options));
        }
    }
}
