using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.AttributeValidation
{
    public class CheckSingleClubCardBL : ICheckSingleClubCardBL
    {
        public readonly IServiceAccountingContext context;

        public CheckSingleClubCardBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> HasClientHaveClubCard(int dealId, int clientId, int? clubCardId)
        {
            var deal = await context.Set<Deal>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dealId);

            if (deal is null)
                throw new ElementNullReferenceException($"{nameof(Deal)} is null");

            if (deal.ClubCardId is null && clubCardId is not null)
            {
                var client = await context.Set<Client>()
                    .AsNoTracking()
                    .Include(x => x.ClientCard)
                    .FirstOrDefaultAsync(x => x.Id == clientId);

                return true;
            }

            return false;
        }
    }
}
