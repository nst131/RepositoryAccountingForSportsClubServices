using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Crud
{
    public class SubscriptionAdditionalOperations : ISubscriptionAdditionalOperations
    {
        private readonly IServiceAccountingContext context;

        public SubscriptionAdditionalOperations(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task AddClientsInSubscription(ICollection<int> clientsId, int subscriptionId)
        {
            var subscriptionToClients = clientsId
                .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

            await context.Set<SubscriptionToClient>().AddRangeAsync(subscriptionToClients);
            await context.SaveChangesAsync();
        }

        public async Task UpdateClientsInSubscription(ICollection<int> clientsId, int subscriptionId, CancellationToken token = default)
        {
            var currentClientsIdBySubscriptionId = await context.Set<SubscriptionToClient>()
                .AsNoTracking()
                .Where(x => x.SubscriptionId == subscriptionId)
                .Select(x => x.ClientId)
                .ToListAsync(token);

            var clientsIdToAdd = clientsId.Except(currentClientsIdBySubscriptionId).ToList();
            if (clientsIdToAdd.Any())
            {
                var subscriptionToClients = clientsIdToAdd
                    .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

                await context.Set<SubscriptionToClient>().AddRangeAsync(subscriptionToClients, token);
            }

            var clientsIdToRemove = currentClientsIdBySubscriptionId.Except(clientsId).ToList();
            if (clientsIdToRemove.Any())
            {
                var subscriptionToClients = clientsIdToRemove
                    .Select(clientId => new SubscriptionToClient() { SubscriptionId = subscriptionId, ClientId = clientId }).ToList();

                await Task.Factory.StartNew(() => context.Set<SubscriptionToClient>().RemoveRange(subscriptionToClients), token);
            }
        }
    }
}
