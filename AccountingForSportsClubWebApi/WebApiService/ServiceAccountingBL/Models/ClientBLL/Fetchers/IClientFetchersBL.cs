using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientBLL.Dto;

namespace ServiceAccountingBL.Models.ClientBLL.Fetchers
{
    public interface IClientFetchersBL
    {
        Task<ICollection<ResponseGetClientDtoBL>> GetClientAll(CancellationToken token = default);
    }
}