using System.Collections.Generic;
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

        public async Task<ICollection<ResponseGetVisitDtoBL>> GetVisitAll()
        {
            if (!await context.Set<Visit>().AnyAsync())
                return new List<ResponseGetVisitDtoBL>();

            var allVisits = await context.Set<Visit>()
                .Include(x => x.Client)
                .Include(x => x.Service)
                .ToListAsync();

            return ReadVisitMapperBL.Map<ICollection<ResponseGetVisitDtoBL>>(allVisits);
        }
    }
}
