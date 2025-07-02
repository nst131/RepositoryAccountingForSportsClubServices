using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.PlaceBLL.Dto;

namespace ServiceAccountingBL.Models.PlaceBLL.Fetchers
{
    public interface IPlaceFetchersBL
    {
        Task<ICollection<ResponseGetPlaceDtoBL>> GetPlaceAll(CancellationToken token = default);
    }
}