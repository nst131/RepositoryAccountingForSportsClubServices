using System.Threading.Tasks;
using ServiceAccountingBL.Models.VisitBLL.Dto;

namespace ServiceAccountingBL.Models.VisitBLL.Crud
{
    public interface IVisitCrudBL
    {
        Task<ResponseVisitDtoBL> CreateVisit(AcceptCreateVisitDtoBL createVisitDtoBL);
        Task<ResponseVisitDtoBL> UpdateVisit(AcceptUpdateVisitDtoBL updateVisitDtoBL);
        Task DeleteVisit(int id);
        Task<ResponseGetVisitDtoBL> GetVisit(int id);
    }
}