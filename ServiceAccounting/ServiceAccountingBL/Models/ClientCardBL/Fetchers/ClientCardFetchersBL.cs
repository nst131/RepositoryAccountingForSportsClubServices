using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClientCardBL.Mapper;

namespace ServiceAccountingBL.Models.ClientCardBL.Fetchers
{
    public class ClientCardFetchersBL : IClientCardFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ClientCardFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetClientCardDtoBL>> GetClientCardAll()
        {
            if (!await context.Set<ClientCard>().AnyAsync())
                return new List<ResponseGetClientCardDtoBL>();

            var allClients = await context.Set<ClientCard>()
                .Include(x => x.Service)
                .Include(x => x.ClubCard)
                .ToListAsync();

            return ReadClientCardMapperBL.Map<ICollection<ResponseGetClientCardDtoBL>>(allClients);
        }
    }
}
