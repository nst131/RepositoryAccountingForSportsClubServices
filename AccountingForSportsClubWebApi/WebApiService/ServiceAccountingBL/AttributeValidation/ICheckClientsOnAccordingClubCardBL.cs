using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface ICheckClientsOnAccordingClubCardBL
    {
        Task<ValidationResult> CheckClientCardOnAccordanceService(int serviceId, int clientId);
    }
}