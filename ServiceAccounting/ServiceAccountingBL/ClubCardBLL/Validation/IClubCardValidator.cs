using System.Threading.Tasks;

namespace ServiceAccountingBL.ClubCardBLL.Validation
{
    public interface IClubCardValidator<T>
    {
        Task Validate(T dto);
    }
}
