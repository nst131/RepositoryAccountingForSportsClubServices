using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Fetchers
{
    public interface ISubscriptionFetchersBL
    {
        Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll();
    }
}