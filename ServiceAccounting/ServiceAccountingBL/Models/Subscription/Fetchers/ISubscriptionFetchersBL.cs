using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.Subscription.Dto;

namespace ServiceAccountingBL.Models.Subscription.Fetchers
{
    public interface ISubscriptionFetchersBL
    {
        Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll();
    }
}