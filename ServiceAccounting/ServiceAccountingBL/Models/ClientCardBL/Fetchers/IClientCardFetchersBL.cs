using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientCardBL.Dto;

namespace ServiceAccountingBL.Models.ClientCardBL.Fetchers
{
    public interface IClientCardFetchersBL
    {
        Task<ICollection<ResponseGetClientCardDtoBL>> GetClientCardAll(CancellationToken token = default);
    }
}