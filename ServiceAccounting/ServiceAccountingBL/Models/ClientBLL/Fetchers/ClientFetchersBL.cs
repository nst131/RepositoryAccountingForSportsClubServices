using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<ICollection<ResponseGetClientDtoBL>> GetClientAll(CancellationToken token = default)
        {
            if (!await context.Set<Client>().AnyAsync(token))
                return new List<ResponseGetClientDtoBL>();

            var allClients = await context.Set<Client>()
                .Include(x => x.TypeSex)
                .ToListAsync(token);

            return ReadClientMapperBL.Map<ICollection<ResponseGetClientDtoBL>>(allClients);
        }
    }
}
