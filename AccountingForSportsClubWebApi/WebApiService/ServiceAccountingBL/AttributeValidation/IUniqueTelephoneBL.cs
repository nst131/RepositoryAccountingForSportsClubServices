using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface IUniqueTelephoneBL
    {
        Task<bool> IsUnique<T>(string telephone) where T : class, ITelephone;
    }
}