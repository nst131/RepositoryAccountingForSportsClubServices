using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Mapper;
using ServiceAccountingDA.Context;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Fetchers
{
    public class SubscriptionFetchersBL : ISubscriptionFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public SubscriptionFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetSubscriptionDtoBL>> GetSubscriptionAll(CancellationToken token = default)
        {
            if (!await context.Set<ServiceAccountingDA.Models.Subscription>().AnyAsync(token))
                return new List<ResponseGetSubscriptionDtoBL>();

            var allSubscriptions = await context.Set<ServiceAccountingDA.Models.Subscription>()
                .Include(x => x.Service)
                .ToListAsync(token);

            return ReadSubscriptionMapperBL.Map<ICollection<ResponseGetSubscriptionDtoBL>>(allSubscriptions);

        }
    }
}
