using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface ICheckCorrectCreateDealBL
    {
        Task<ValidationResult> ValidateCreateDeal(int clientId, int? clubCardId, int? subscriptionId);
    }
}