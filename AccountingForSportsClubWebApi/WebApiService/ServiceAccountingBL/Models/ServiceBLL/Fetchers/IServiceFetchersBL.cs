using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ServiceBLL.Dto;

namespace ServiceAccountingBL.Models.ServiceBLL.Fetchers
{
    public interface IServiceFetchersBL
    {
        Task<ICollection<ResponseGetServiceDtoBL>> GetServiceAll(CancellationToken token = default);
    }
}