using System.Threading.Tasks;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Crud
{
    public interface ISubscriptionCrudBL
    {
        Task<ResponseSubscriptionDtoBL> CreateSubscription(AcceptCreateSubscriptionDtoBL createSubscriptionDtoBL);
        Task<ResponseSubscriptionDtoBL> UpdateSubscription(AcceptUpdateSubscriptionDtoBL updateSubscriptionDtoBL);
        Task DeleteSubscription(int id);
        Task<ResponseGetSubscriptionDtoBL> GetSubscription(int id);
    }
}