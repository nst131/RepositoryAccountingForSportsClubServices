using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.BaseModels;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Fetchers
{
    [TegForRedis(KeyTags.Subscription)]
    public interface ISubscriptionFetchersBL
    {
        Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll(CancellationToken token = default);
    }
}