using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.DealBLL.Dto;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public interface IDealCrudBL
    {
        Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL, CancellationToken token = default);
        Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL, CancellationToken token = default);
        Task DeleteDeal(int id, CancellationToken token = default);
        Task<ResponseGetDealDtoBL> GetDeal(int id, CancellationToken token = default);
    }
}