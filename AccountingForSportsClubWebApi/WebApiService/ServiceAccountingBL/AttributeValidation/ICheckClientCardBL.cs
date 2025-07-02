using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface ICheckClientCardBL
    {
        Task<bool> ExistClientCard(int clientId);
    }
}