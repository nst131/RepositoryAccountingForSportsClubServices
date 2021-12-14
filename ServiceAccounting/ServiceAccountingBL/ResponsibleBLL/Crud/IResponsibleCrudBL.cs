using ServiceAccountingBL.ResponsibleBLL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ResponsibleBLL.Crud
{
    public interface IResponsibleCrudBL
    {
        Task<ResponsibleDtoBL> CreateResponsible(CreateResponsibleDtoBL createResponsibleDtoBL);
        Task DeleteResponsible(int id);
        Task<GetResponsibleDtoBL> GetResponsible(int id);
        Task<ICollection<GetResponsibleDtoBL>> GetResponsibleAll();
        Task<ResponsibleDtoBL> UpdateResponsible(UpdateResponsibleDtoBL updateResponsibleDtoBL);
    }
}