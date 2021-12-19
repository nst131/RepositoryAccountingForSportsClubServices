using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Crud
{
    public interface IResponsibleCrudBL
    {
        Task<ResponsibleDtoBL> CreateResponsible(CreateResponsibleDtoBL createResponsibleDtoBL);
        Task DeleteResponsible(int id);
        Task<GetResponsibleDtoBL> GetResponsible(int id);
        Task<ResponsibleDtoBL> UpdateResponsible(UpdateResponsibleDtoBL updateResponsibleDtoBL);
    }
}