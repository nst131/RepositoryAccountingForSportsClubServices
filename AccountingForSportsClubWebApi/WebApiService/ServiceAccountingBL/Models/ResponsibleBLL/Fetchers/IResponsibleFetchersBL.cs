using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Fetchers
{
    public interface IResponsibleFetchersBL
    {
        Task<ICollection<ResponseGetResponsibleDtoBL>> GetResponsibleAll(CancellationToken token = default);
    }
}