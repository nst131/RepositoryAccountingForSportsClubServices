using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<ICollection<ResponseGetDealDtoBL>> GetDealAll(CancellationToken token = default)
        {
            if (!await context.Set<Deal>().AnyAsync(token))
                return new List<ResponseGetDealDtoBL>();

            var allDeals = await context.Set<Deal>()
                .Include(x => x.Subscription)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.ClubCard)
                .ToListAsync(token);

            return ReadDealMapperBL.Map<ICollection<ResponseGetDealDtoBL>>(allDeals);
        }

        public async Task<int> GetResponsibleIdByDealId(int dealId, CancellationToken token)
        {
            var responsibleId = await context.Set<Deal>().AsNoTracking().Where(x => x.Id == dealId).Select(x => x.ResponsibleId).FirstOrDefaultAsync(token);
            return responsibleId;
        }
    }
}
