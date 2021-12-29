using System.Threading.Tasks;
using ServiceAccountingBL.Models.Subscription.Dto;

namespace ServiceAccountingBL.Models.Subscription.Crud
{
    public interface ISubscriptionCrudBL
    {
        Task<ResponseSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL);
        Task<ResponseSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL);
        Task DeleteSubscription(int id);
        Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id);
    }
}