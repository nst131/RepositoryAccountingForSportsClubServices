using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.DealBLL.Dto;

namespace ServiceAccountingBL.Models.DealBLL.Fetchers
{
    public interface IDealFetchersBL
    {
        Task<ICollection<ResponseGetDealDtoBL>> GetDealAll(CancellationToken token = default);
        Task<int> GetResponsibleIdByDealId(int dealId, CancellationToken token);
    }
}