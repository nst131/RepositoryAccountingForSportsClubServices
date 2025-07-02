using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.VisitBLL.Dto;

namespace ServiceAccountingBL.Models.VisitBLL.Crud
{
    public interface IVisitCrudBL
    {
        Task<ResponseVisitDtoBL> CreateVisit(AcceptCreateVisitDtoBL createVisitDtoBL, CancellationToken token = default);
        Task<ResponseVisitDtoBL> UpdateVisit(AcceptUpdateVisitDtoBL updateVisitDtoBL, CancellationToken token = default);
        Task DeleteVisit(int id, CancellationToken token = default);
        Task<ResponseGetVisitDtoBL> GetVisit(int id, CancellationToken token = default);
    }
}