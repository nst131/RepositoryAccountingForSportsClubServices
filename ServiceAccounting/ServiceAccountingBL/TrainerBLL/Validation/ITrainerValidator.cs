using System.Threading.Tasks;

namespace ServiceAccountingBL.TrainerBLL.Validation
{
    public interface ITrainerValidator<T>
    {
        Task Validate(T item);
    }
}
