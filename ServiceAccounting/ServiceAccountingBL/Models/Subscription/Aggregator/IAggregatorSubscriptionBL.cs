using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.Subscription.Crud;
using ServiceAccountingBL.Models.Subscription.Dto;
using ServiceAccountingBL.Models.Subscription.Fetchers;

namespace ServiceAccountingBL.Models.Subscription.Aggregator
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