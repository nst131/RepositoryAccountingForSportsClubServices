using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Fetchers
{
    public class ClientFetchersBL : IClientFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ClientFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetClientDtoBL>> GetClientAll()
        {
            if (!await context.Set<Client>().AnyAsync()) 
                return new List<ResponseGetClientDtoBL>();

            var allClients = await context.Set<Client>()
                .Include(x => x.TypeSex)
                .ToListAsync();

            return ReadClientMapperBL.Map<ICollection<ResponseGetClientDtoBL>>(allClients);

        }
    }
}
