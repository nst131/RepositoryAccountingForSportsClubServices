using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Validation
{
    public interface IClientValidator<T>
    {
        Task Validate(T dto);
    }
}