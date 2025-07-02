using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;

namespace ServiceAccountingBL.Models.ClubCardBLL.Fetchers
{
    public interface IClubCardFetchersBL
    {
        Task<ICollection<ResponseGetClubCardDtoBL>> GetClubCardAll(CancellationToken token = default);
    }
}