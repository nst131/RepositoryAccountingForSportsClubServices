using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public class ResponseVisitMapperBL : IMapperAsync<Visit, ResponseVisitDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public ResponseVisitMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseVisitDtoBL> Map(Visit dto)
        {
            var visitWithClient = await context.Set<Visit>()
                .Include(x => x.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            return new ResponseVisitDtoBL()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ClientName = visitWithClient.Client.Name
            };
        }
    }
}