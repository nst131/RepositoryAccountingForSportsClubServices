using RedisLibrary.Attributes;
using ServiceAccountingBL.BaseModels;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Fetchers
{
    [TegForRedis(KeyTags.Subscription)]
    public interface ISubscriptionFetchersBL
    {
        Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll(CancellationToken token = default);
    }
}