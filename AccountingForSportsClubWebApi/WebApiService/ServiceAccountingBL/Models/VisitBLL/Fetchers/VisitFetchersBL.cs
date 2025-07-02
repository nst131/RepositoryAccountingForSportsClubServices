using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Fetchers
{
    public class VisitFetchersBL : IVisitFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public VisitFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetVisitDtoBL>> GetVisitAll(CancellationToken token = default)
        {
            if (!await context.Set<Visit>().AnyAsync(token))
                return new List<ResponseGetVisitDtoBL>();

            var allVisits = await context.Set<Visit>()
                .Include(x => x.Client)
                .Include(x => x.Service)
                .ToListAsync(token);

            return ReadVisitMapperBL.Map<ICollection<ResponseGetVisitDtoBL>>(allVisits);
        }
    }
}
