using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public class ResponseVisitMapperBL : IMapper<Visit, ResponseVisitDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public ResponseVisitMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public ResponseVisitDtoBL Map(Visit dto)
        {
            var visitWithClient = context.Set<Visit>()
                .Include(x => x.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            return new ()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ClientName = visitWithClient.Result.Client.Name
            };
        }
    }
}