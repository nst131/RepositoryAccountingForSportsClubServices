using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.AttributeValidation
{
    public class UniqueSubscriptionBL : IUniqueSubscriptionBL
    {
        public readonly IServiceAccountingContext context;

        public UniqueSubscriptionBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> HasClientHaveSubscription(int dealId, int clientId, int? subscriptionId)
        {
            var deal = await context.Set<Deal>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dealId);

            if (deal is null)
                throw new ElementNullReferenceException($"{nameof(Deal)} is null");

            if (subscriptionId is not null && deal.SubscriptionId != subscriptionId)
            {
                var bind = await this.context.Set<SubscriptionToClient>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.ClientId == clientId &&
                        x.SubscriptionId == subscriptionId);

                if (bind is not null)
                    return true;
            }

            return false;
        }
    }
}
