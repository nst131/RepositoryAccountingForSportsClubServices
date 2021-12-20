using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Crud
{
    public interface IResponsibleCrudBL
    {
        Task<ResponseResponsibleDtoBL> CreateResponsible(AcceptCreateResponsibleDtoBL createResponsibleDtoBL);
        Task DeleteResponsible(int id);
        Task<ResponseGetResponsibleDtoBL> GetResponsible(int id);
        Task<ResponseResponsibleDtoBL> UpdateResponsible(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL);
    }
}