using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public class GetVisitMapperBL : IMapperAsync<int, ResponseGetVisitDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetVisitMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetVisitDtoBL> Map(int id)
        {
            var dto = await context.Set<Visit>()
                .Include(x => x.Client)
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetVisitDtoBL()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ClientName = dto.Client.Name,
                ServiceName = dto.Service.Name
            };
        }
    }
}
