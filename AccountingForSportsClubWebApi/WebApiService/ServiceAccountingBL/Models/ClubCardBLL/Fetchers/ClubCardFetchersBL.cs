using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Fetchers
{
    public class ClubCardFetchersBL : IClubCardFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ClubCardFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetClubCardDtoBL>> GetClubCardAll(CancellationToken token = default)
        {
            if (!await context.Set<ClubCard>().AnyAsync(token)) 
                return new List<ResponseGetClubCardDtoBL>();

            var allClubCards = await context.Set<ClubCard>()
                .Include(x => x.Service)
                .ToListAsync(token);

            return ReadClubCardMapperBL.Map<ICollection<ResponseGetClubCardDtoBL>>(allClubCards);

        }
    }
}
