using System.Threading.Tasks;
using ServiceAccountingBL.Models.PlaceBLL.Dto;

namespace ServiceAccountingBL.Models.PlaceBLL.Crud
{
    public interface IPlaceCrudBL
    {
        Task<ResponsePlaceDtoBL> CreatePlace(AcceptCreatePlaceDtoBL createPlaceDtoBL);
        Task<ResponsePlaceDtoBL> UpdatePlace(AcceptUpdatePlaceDtoBL updatePlaceDtoBL);
        Task DeletePlace(int id);
        Task<ResponseGetPlaceDtoBL> GetPlace(int id);
    }
}