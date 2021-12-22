using System.Collections.Generic;
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

        public async Task<ICollection<ResponseGetServiceDtoBL>> GetServiceAll()
        {
            if (!await context.Set<Service>().AnyAsync())
                return new List<ResponseGetServiceDtoBL>();

            var allServices = await context.Set<Service>()
                .Include(x => x.Place)
                .ToListAsync();

            return ReadServiceMapperBL.Map<ICollection<ResponseGetServiceDtoBL>>(allServices);

        }
    }
}
