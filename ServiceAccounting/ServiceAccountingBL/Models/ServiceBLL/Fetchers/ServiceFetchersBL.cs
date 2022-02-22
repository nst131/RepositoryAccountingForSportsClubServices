using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ServiceBLL.Fetchers
{
    public class ServiceFetchersBL : IServiceFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ServiceFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetServiceDtoBL>> GetServiceAll(CancellationToken token = default)
        {
            if (!await context.Set<Service>().AnyAsync(token))
                return new List<ResponseGetServiceDtoBL>();

            var allServices = await context.Set<Service>()
                .Include(x => x.Place)
                .ToListAsync(token);

            return ReadServiceMapperBL.Map<ICollection<ResponseGetServiceDtoBL>>(allServices);

        }
    }
}
