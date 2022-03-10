using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Aggregator
{
    public class AggregatorSubscriptionBL : IAggregatorSubscriptionBL
    {
        private readonly Lazy<ISubscriptionCrudBL> subscriptionCrudBL;
        private readonly Lazy<ISubscriptionFetchersBL> subscriptionFetchersBL;
        private readonly Lazy<IRemover<Subscription>> removeSubscription;
        private readonly Lazy<IGetter<ResponseGetSubscriptionDtoBL>> getSubscription;

        private readonly Lazy<IValidator<AcceptCreateSubscriptionDtoBL>> createValidator;
        private readonly Lazy<IValidator<AcceptUpdateSubscriptionDtoBL>> updateValidator;

        public AggregatorSubscriptionBL(Lazy<ISubscriptionCrudBL> subscriptionCrudBL,
            Lazy<ISubscriptionFetchersBL> subscriptionFetchersBL,
            Lazy<IRemover<Subscription>> removeSubscription,
            Lazy<IGetter<ResponseGetSubscriptionDtoBL>> getSubscription,
            Lazy<IValidator<AcceptCreateSubscriptionDtoBL>> createValidator,
            Lazy<IValidator<AcceptUpdateSubscriptionDtoBL>> updateValidator)
        {
            this.subscriptionCrudBL = subscriptionCrudBL;
            this.subscriptionFetchersBL = subscriptionFetchersBL;
            this.removeSubscription = removeSubscription;
            this.getSubscription = getSubscription;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        public ISubscriptionCrudBL SubscriptionCrudBL => subscriptionCrudBL.Value;
        public ISubscriptionFetchersBL SubscriptionFetchersBL => subscriptionFetchersBL.Value;
        public IRemover<Subscription> RemoveSubscription => removeSubscription.Value;
        public IGetter<ResponseGetSubscriptionDtoBL> GetSubscription => getSubscription.Value;

        public IValidator<AcceptCreateSubscriptionDtoBL> CreateValidator => createValidator.Value;
        public IValidator<AcceptUpdateSubscriptionDtoBL> UpdateValidator => updateValidator.Value;
    }
}
