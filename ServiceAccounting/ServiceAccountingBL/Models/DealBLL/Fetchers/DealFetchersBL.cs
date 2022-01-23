using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Fetchers
{
    public class DealFetchersBL : IDealFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public DealFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetDealDtoBL>> GetDealAll()
        {
            if (!await context.Set<Deal>().AnyAsync())
                return new List<ResponseGetDealDtoBL>();

            var allDeals = await context.Set<Deal>()
                .Include(x => x.Subscription)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.ClubCard)
                .ToListAsync();

            return ReadDealMapperBL.Map<ICollection<ResponseGetDealDtoBL>>(allDeals);

        }
    }
}
