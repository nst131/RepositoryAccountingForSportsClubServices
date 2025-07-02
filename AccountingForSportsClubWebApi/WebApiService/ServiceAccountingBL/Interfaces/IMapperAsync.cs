using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IMapperAsync<FromDto, ToDto>
        where ToDto : class
    {
        Task<ToDto> Map(FromDto dto);
    }
}
