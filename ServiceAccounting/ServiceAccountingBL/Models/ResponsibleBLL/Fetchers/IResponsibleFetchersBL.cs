using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Fetchers
{
    public interface IResponsibleFetchersBL
    {
        Task<ICollection<GetResponsibleDtoBL>> GetResponsibleAll();
    }
}