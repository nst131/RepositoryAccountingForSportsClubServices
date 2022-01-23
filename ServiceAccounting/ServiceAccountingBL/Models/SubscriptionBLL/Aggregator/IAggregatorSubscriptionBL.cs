using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Aggregator
{
    public interface IAggregatorSubscriptionBL
    {
        ISubscriptionCrudBL SubscriptionCrudBL { get; }
        ISubscriptionFetchersBL SubscriptionFetchersBL { get; }
        IRemover<ServiceAccountingDA.Models.Subscription> RemoveSubscription { get; }
        IGetter<ResponseGetSubscriptionDtoBL> GetSubscription { get; }
        IValidator<AcceptCreateSubscriptionDtoBL> CreateValidator { get; }
        IValidator<AcceptUpdateSubscriptionDtoBL> UpdateValidator { get; }
    }
}