using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.DealBLL.Dto;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public interface IDealAdditionalOperations
    {
        Task AddClientCard(AcceptCreateDealDtoBL createDealDealDtoBl, CancellationToken token);
        Task AddSubscriptionToClient(AcceptCreateDealDtoBL createDealDealDtoBl, CancellationToken token);
        Task DeleteClientCard(int clientId);
        Task DeleteSubscriptionToClient(int clientId, int subscriptionId, CancellationToken token);
    }
}