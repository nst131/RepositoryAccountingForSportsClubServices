using RedisLibrary.Attributes;
using ServiceAccountingBL.BaseModels;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Crud
{
    [TegForRedis(KeyTags.Subscription)]
    public interface ISubscriptionCrudBL
    {
        Task<ResponseGetSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL, CancellationToken token = default);
        Task<ResponseGetSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL, CancellationToken token = default);
        Task<int> DeleteSubscription(int id, CancellationToken token = default);
        Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id, CancellationToken token = default);
    }
}