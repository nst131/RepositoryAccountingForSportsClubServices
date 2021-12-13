using ServiceAccountingDA.Interfaces;
using System.Threading.Tasks;

namespace ServiceAccountingBL.AdditionalValidation
{
    public interface IUniqueTelephoneBL
    {
        Task<bool> IsUnique<T>(string telephone) where T : class, ITelephone;
    }
}