using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public class GetDealMapperBL : IMapperAsync<int ,ResponseGetDealDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetDealMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetDealDtoBL> Map(int id)
        {
            var dto = await context.Set<Deal>()
                .Include(x => x.Subscription)
                .Include(x => x.Client)
                .Include(x => x.Responsible)
                .Include(x => x.ClubCard)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetDealDtoBL()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dto.Client.Name, //? Load Client (must be requied)
                ClubCardName = dto.ClubCard?.Name, //? Load ClubCard (can be null)
                ResponsibleName = dto.Responsible.Name, //? Load Responsible (must be reqired)
                SubscriptionName = dto.Subscription?.Name, //? Load Subscription (can be null)
                SubscriptionAmountWorkouts = dto.Subscription?.AmountWorkouts //? Load Subscription (can be null)
            };
        }
    }
}
