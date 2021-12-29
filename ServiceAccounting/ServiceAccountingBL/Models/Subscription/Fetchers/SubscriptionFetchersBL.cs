using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.Subscription.Dto;
using ServiceAccountingBL.Models.Subscription.Mapper;
using ServiceAccountingDA.Context;

namespace ServiceAccountingBL.Models.Subscription.Fetchers
{
    public class SubscriptionFetchersBL : ISubscriptionFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public SubscriptionFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll()
        {
            if (!await context.Set<ServiceAccountingDA.Models.Subscription>().AnyAsync())
                return new List<ResponseGetSubscriptionDtoBL>();

            var allSubscriptions = await context.Set<ServiceAccountingDA.Models.Subscription>()
                .Include(x => x.Service)
                .ToListAsync();

            return ReadSubscriptionMapperBL.Map<ICollection<ResponseGetSubscriptionDtoBL>>(allSubscriptions);

        }
    }
}
