using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Crud
{
    public interface ISubscriptionAdditionalOperations
    {
        Task AddClientsInSubscription(ICollection<int> clientsId, int subscriptionId);
        Task UpdateClientsInSubscription(ICollection<int> clientsId, int subscriptionId, CancellationToken token = default);
    }
}