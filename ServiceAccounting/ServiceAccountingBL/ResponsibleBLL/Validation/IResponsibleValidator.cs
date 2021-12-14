using System.Threading.Tasks;

namespace ServiceAccountingBL.ResponsibleBLL.Validation
{
    public interface IResponsibleValidator<T>
    {
        Task Validate(T item);
    }
}
