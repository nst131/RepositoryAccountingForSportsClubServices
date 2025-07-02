using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Validation
{
    public class ReturnableUpdateDealValidation : IReternableValidator<AcceptUpdateDealDtoBL, Deal>
    {
        public readonly IServiceAccountingContext context;

        public ReturnableUpdateDealValidation(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<Deal> Validate(AcceptUpdateDealDtoBL dto, CancellationToken token = default)
        {
            var deal = await context.Set<Deal>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id, token);

            if (deal is null)
                throw new ElementNullReferenceException($"{nameof(Deal)} is null");

            if (deal.ClubCardId is null && dto.ClubCardId is not null)
            {
                var client = await context.Set<Client>()
                    .AsNoTracking()
                    .Include(x => x.ClientCard)
                    .FirstOrDefaultAsync(x => x.Id == dto.ClientId, token);

                if (client.ClientCard is null)
                    throw new ElementAlreadyExistException($"{nameof(Client)} has have this {nameof(ClubCard)} yet");
            }

            if (dto.SubscriptionId is not null && deal.SubscriptionId != dto.SubscriptionId)
            {
                var bind = await this.context.Set<SubscriptionToClient>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.ClientId == dto.ClientId &&
                        x.SubscriptionId == dto.SubscriptionId, token);

                if (bind is not null)
                    throw new ElementAlreadyExistException($"{nameof(Client)} has have this {nameof(Subscription)} yet");
            }

            return deal;
        }
    }
}
