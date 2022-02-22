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

        public SubscriptionCrudBL(IServiceAccountingContext context, 
            IAggregatorSubscriptionBL aggregator, 
            IMapperAsync<int, ResponseGetSubscriptionDtoBL> getSubscriptionMapperBl)
        {
            this.context = context;
            this.removeSubscription = aggregator.RemoveSubscription;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getSubscription = aggregator.GetSubscription;
            this.getSubscriptionMapperBL = getSubscriptionMapperBl;
        }

        public async Task<ResponseGetSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL, CancellationToken token = default)
        {
            await createValidator.Validate(createSubscriptionDtoBL);

            var subscription = CreateSubscriptionMapperBL.Map<Subscription>(createSubscriptionDtoBL);
            var addedSubscription = await context.Set<Subscription>().AddAsync(subscription, token);
            await context.SaveChangesAsync(token);

            if (createSubscriptionDtoBL.ClientsId is not null && createSubscriptionDtoBL.ClientsId.Any())
            {
                await AddClientsInSubscription(createSubscriptionDtoBL.ClientsId, addedSubscription.Entity.Id);
            }

            return await getSubscriptionMapperBL.Map(addedSubscription.Entity.Id);
        }

        private async Task AddClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId)
        {
            var subscriptionToClients = clientsId
                .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

            await context.Set<SubscriptionToClient>().AddRangeAsync(subscriptionToClients);
            await context.SaveChangesAsync();
        }

        public async Task<ResponseGetSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL, CancellationToken token = default)
        {
            await updateValidator.Validate(updateSubscriptionDtoBL);

            var subscription = UpdateSubscriptionMapperBL.Map<Subscription>(updateSubscriptionDtoBL);
            await Task.Factory.StartNew(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                return context.Set<Subscription>().Update(subscription);
            }, token);

            await UpdateClientsInSubscription(updateSubscriptionDtoBL.ClientsId, updateSubscriptionDtoBL.Id, token);

            await context.SaveChangesAsync(token);

            return await getSubscriptionMapperBL.Map(subscription.Id);
        }

        private async Task UpdateClientsInSubscription(IEnumerable<int> clientsId, int subscriptionId, CancellationToken token = default)
        {
            var currentClientsIdBySubscriptionId = await context.Set<SubscriptionToClient>()
                .AsNoTracking()
                .Where(x => x.SubscriptionId == subscriptionId)
                .Select(x => x.ClientId)
                .ToListAsync(token);

            var t1 = Task.Run(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                AddClientsInSubscription(clientsId, subscriptionId, currentClientsIdBySubscriptionId);
            }, token);

            var t2 = Task.Run(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                RemoveClientsInSubscription(clientsId, subscriptionId, currentClientsIdBySubscriptionId);
            }, token);

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

        public async Task<int> DeleteSubscription(int id, CancellationToken token = default)
            => await removeSubscription.Remove(id, token);

        public async Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id, CancellationToken token = default)
            => await getSubscription.Get(id, token);
    }
}