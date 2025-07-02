using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface ICheckSingleClubCardBL
    {
        Task<bool> HasClientHaveClubCard(int dealId ,int clientId, int? clubCardId);
    }
}