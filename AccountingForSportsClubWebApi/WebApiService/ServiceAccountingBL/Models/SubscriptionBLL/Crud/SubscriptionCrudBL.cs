using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.SubscriptionBLL.Aggregator;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Crud
{
    public class SubscriptionCrudBL : ISubscriptionCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<AcceptCreateSubscriptionDtoBL> createValidator;
        private readonly IValidator<AcceptUpdateSubscriptionDtoBL> updateValidator;
        private readonly IRemover<Subscription> removeSubscription;
        private readonly IGetter<ResponseGetSubscriptionDtoBL> getSubscription;
        private readonly IMapperAsync<int, ResponseGetSubscriptionDtoBL> getSubscriptionMapperBL;
        private readonly ISubscriptionAdditionalOperations subscriptionAdditionalOperations;

        public SubscriptionCrudBL(IServiceAccountingContext context, 
            IAggregatorSubscriptionBL aggregator, 
            IMapperAsync<int, ResponseGetSubscriptionDtoBL> getSubscriptionMapperBl,
            ISubscriptionAdditionalOperations subscriptionAdditionalOperations)
        {
            this.context = context;
            this.removeSubscription = aggregator.RemoveSubscription;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getSubscription = aggregator.GetSubscription;
            this.getSubscriptionMapperBL = getSubscriptionMapperBl;
            this.subscriptionAdditionalOperations = subscriptionAdditionalOperations;
        }

        public async Task<ResponseGetSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL, CancellationToken token = default)
        {
            await createValidator.Validate(createSubscriptionDtoBL);

            var subscription = CreateSubscriptionMapperBL.Map<Subscription>(createSubscriptionDtoBL);
            var addedSubscription = await context.Set<Subscription>().AddAsync(subscription, token);
            await context.SaveChangesAsync(token);

            if (createSubscriptionDtoBL.ClientsId is not null && createSubscriptionDtoBL.ClientsId.Any())
            {
                await this.subscriptionAdditionalOperations.AddClientsInSubscription(createSubscriptionDtoBL.ClientsId, addedSubscription.Entity.Id);
            }

            return await getSubscriptionMapperBL.Map(addedSubscription.Entity.Id);
        }

        public async Task<ResponseGetSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL, CancellationToken token = default)
        {
            await updateValidator.Validate(updateSubscriptionDtoBL);

            var subscription = UpdateSubscriptionMapperBL.Map<Subscription>(updateSubscriptionDtoBL);
            await Task.Factory.StartNew(() =>
            {
                if (token.IsCancellationRequested)
                    throw new TaskCanceledException();
                
                return context.Set<Subscription>().Update(subscription);
            }, token);

            await this.subscriptionAdditionalOperations.UpdateClientsInSubscription(updateSubscriptionDtoBL.ClientsId, updateSubscriptionDtoBL.Id, token);

            await context.SaveChangesAsync(token);

            return await getSubscriptionMapperBL.Map(subscription.Id);
        }

        public async Task<int> DeleteSubscription(int id, CancellationToken token = default)
            => await removeSubscription.Remove(id, token);

        public async Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id, CancellationToken token = default)
            => await getSubscription.Get(id, token);
    }
}