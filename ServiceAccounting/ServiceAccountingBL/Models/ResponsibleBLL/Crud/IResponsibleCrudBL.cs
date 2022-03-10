using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Crud
{
    public interface IResponsibleCrudBL
    {
        Task<ResponseResponsibleDtoBL> CreateResponsible(AcceptCreateResponsibleDtoBL createResponsibleDtoBL, CancellationToken token = default);
        Task DeleteResponsible(int id, CancellationToken token = default);
        Task<ResponseGetResponsibleDtoBL> GetResponsible(int id, CancellationToken token = default);
        Task<ResponseResponsibleDtoBL> UpdateResponsible(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL, CancellationToken token = default);
    }
}