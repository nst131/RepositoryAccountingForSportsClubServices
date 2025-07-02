using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public class ResponseDealMapperBL : IMapperAsync<Deal, ResponseDealDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public ResponseDealMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseDealDtoBL> Map(Deal dto)
        {
            var dealWithClient = await context.Set<Deal>()
                .Include(x => x.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            return new ResponseDealDtoBL()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dealWithClient.Client.Name //Load Client
            };
        }
    }
}