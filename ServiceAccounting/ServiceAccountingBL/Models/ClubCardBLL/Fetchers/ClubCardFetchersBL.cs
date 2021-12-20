using System.Collections.Generic;
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

        public async Task<ICollection<ResponseGetClubCardDtoBL>> GetClubCardAll()
        {
            if (!await context.Set<ClubCard>().AnyAsync()) 
                return new List<ResponseGetClubCardDtoBL>();

            var allClubCards = await context.Set<ClubCard>()
                .Include(x => x.Service)
                .ToListAsync();

            return ReadClubCardMapperBL.Map<ICollection<ResponseGetClubCardDtoBL>>(allClubCards);

        }
    }
}
