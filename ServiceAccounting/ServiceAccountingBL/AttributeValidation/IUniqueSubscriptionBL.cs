using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface IUniqueSubscriptionBL
    {
        Task<bool> HasClientHaveSubscription(int dealId, int clientId, int? subscriptionId);
    }
}