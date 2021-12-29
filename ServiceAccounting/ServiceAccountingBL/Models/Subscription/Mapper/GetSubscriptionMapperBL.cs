using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.Subscription.Dto;
using ServiceAccountingDA.Context;

namespace ServiceAccountingBL.Models.Subscription.Mapper
{
    public class GetSubscriptionMapperBL : IMapperAsync<int ,ResponseGetSubscriptionDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetSubscriptionMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetSubscriptionDtoBL> Map(int id)
        {
            var dto = await context.Set<ServiceAccountingDA.Models.Subscription>()
                .Include(x => x.Service)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetSubscriptionDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceName = dto.Service.Name
            };
        }
    }
}
