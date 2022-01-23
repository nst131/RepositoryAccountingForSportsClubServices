using System.Collections.Generic;
using System.Linq;
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
        private readonly IRemover<ServiceAccountingDA.Models.Subscription> removeSubscription;
        private readonly IGetter<ResponseGetSubscriptionDtoBL> getSubscription;

        public SubscriptionCrudBL(IServiceAccountingContext context, IAggregatorSubscriptionBL aggregator)
        {
            this.context = context;
            this.removeSubscription = aggregator.RemoveSubscription;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getSubscription = aggregator.GetSubscription;
        }

        public async Task<ResponseSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL)
        {
            await createValidator.Validate(createSubscriptionDtoBL);

            var subscription = CreateSubscriptionMapperBL.Map<ServiceAccountingDA.Models.Subscription>(createSubscriptionDtoBL);
            var addedSubscription = await context.Set<ServiceAccountingDA.Models.Subscription>().AddAsync(subscription);
            await context.SaveChangesAsync();

            if (createSubscriptionDtoBL.ClientsId is not null && createSubscriptionDtoBL.ClientsId.Any())
            {
                await AddClientsInSubscription(createSubscriptionDtoBL.ClientsId, addedSubscription.Entity.Id);
            }

            return ResponseSubscriptionMapperBL.Map<ResponseSubscriptionDtoBL>(addedSubscription.Entity);
        }

        private async Task AddClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId)
        {
            var subscriptionToClients = clientsId
                .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

            await context.Set<SubscriptionToClient>().AddRangeAsync(subscriptionToClients);
            await context.SaveChangesAsync();
        }

        public async Task<ResponseSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL)
        {
            await updateValidator.Validate(updateSubscriptionDtoBL);

            var subscription = UpdateSubscriptionMapperBL.Map<ServiceAccountingDA.Models.Subscription>(updateSubscriptionDtoBL);
            await Task.Factory.StartNew(() => context.Set<ServiceAccountingDA.Models.Subscription>().Update(subscription));
            await UpdateClientsInSubscription(updateSubscriptionDtoBL.ClientsId, updateSubscriptionDtoBL.Id);

            await context.SaveChangesAsync();

            return ResponseSubscriptionMapperBL.Map<ResponseSubscriptionDtoBL>(subscription);
        }

        private async Task UpdateClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId)
        {
            var currentClientsIdBySubscriptionId = await context.Set<SubscriptionToClient>()
                .AsNoTracking()
                .Where(x => x.SubscriptionId == subscriptionId)
                .Select(x => x.ClientId)
                .ToListAsync();

            var t1 = Task.Run(() => AddClientsInSubscription(clientsId, subscriptionId, currentClientsIdBySubscriptionId));
            var t2 = Task.Run(() => RemoveClientsInSubscription(clientsId, subscriptionId, currentClientsIdBySubscriptionId));

            await Task.WhenAll(t1, t2);
        }

        private async void AddClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId, IEnumerable<int> currentClientsId)
        {
            var clientsIdToAdd = clientsId.Except(currentClientsId).ToList();
            if (clientsIdToAdd.Any())
            {
                var subscriptionToClients = clientsIdToAdd
                    .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

                await context.Set<SubscriptionToClient>().AddRangeAsync(subscriptionToClients);
            }
        }

        private async void RemoveClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId, IEnumerable<int> currentClientsId)
        {
            var clientsIdToRemove = currentClientsId.Except(clientsId).ToList();
            if (clientsIdToRemove.Any())
            {
                var subscriptionToClients = clientsIdToRemove
                    .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

                await Task.Factory.StartNew(() => context.Set<SubscriptionToClient>().RemoveRange(subscriptionToClients));
            }
        }

        public async Task DeleteSubscription(int id)
            => await removeSubscription.Remove(id);

        public async Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id)
            => await getSubscription.Get(id);
    }
}