using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.PlaceBLL.Dto;

namespace ServiceAccountingBL.Models.PlaceBLL.Crud
{
    public interface IPlaceCrudBL
    {
        Task<ResponsePlaceDtoBL> CreatePlace(AcceptCreatePlaceDtoBL createPlaceDtoBL, CancellationToken token = default);
        Task<ResponsePlaceDtoBL> UpdatePlace(AcceptUpdatePlaceDtoBL updatePlaceDtoBL, CancellationToken token = default);
        Task DeletePlace(int id, CancellationToken token = default);
        Task<ResponseGetPlaceDtoBL> GetPlace(int id, CancellationToken token = default);
    }
}