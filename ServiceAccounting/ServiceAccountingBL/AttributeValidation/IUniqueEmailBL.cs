using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface IUniqueEmailBL
    {
        Task<bool> IsUnique<T>(string email) where T : class, IEmail;
    }
}