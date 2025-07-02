using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public interface ICheckServiceByTrainerBL
    {
        Task<bool> IsSameService(int serviceId, int trainerId);
    }
}