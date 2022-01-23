using System.Threading.Tasks;
using ServiceAccountingBL.Models.DealBLL.Dto;

namespace ServiceAccountingBL.Models.DealBLL.Crud
{
    public interface IDealCrudBL
    {
        Task<ResponseDealDtoBL> CreateDeal(AcceptCreateDealDtoBL createDealDtoBL);
        Task<ResponseDealDtoBL> UpdateDeal(AcceptUpdateDealDtoBL updateDealDtoBL);
        Task DeleteDeal(int id);
        Task<ResponseGetDealDtoBL> GetDeal(int id);
    }
}