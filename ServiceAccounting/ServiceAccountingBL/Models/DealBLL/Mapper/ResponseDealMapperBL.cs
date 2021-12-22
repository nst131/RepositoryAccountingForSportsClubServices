using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public class ResponseDealMapperBL : IMapper<Deal, ResponseDealDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public ResponseDealMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public ResponseDealDtoBL Map(Deal dto)
        {
            var dealWithClient = context.Set<Deal>().Include(x => x.Client).AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            
            if(dealWithClient is null)
                throw new ElementByIdNotFoundException($"{nameof(Deal)} by Id not Found");

            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dealWithClient.Result.Client.Name //Load Client
            };
        }
    }
}