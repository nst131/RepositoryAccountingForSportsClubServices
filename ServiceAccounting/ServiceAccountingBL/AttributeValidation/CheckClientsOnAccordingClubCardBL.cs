using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.AttributeValidation
{
    public class CheckClientsOnAccordingClubCardBL : ICheckClientsOnAccordingClubCardBL
    {
        private readonly IServiceAccountingContext context;

        public CheckClientsOnAccordingClubCardBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ValidationResult> CheckClientCardOnAccordanceService(int serviceId, int clientId)
        {
            var client = await this.context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.ClientCard)
                .FirstOrDefaultAsync(x => x.Id == clientId);

            var clientCard = client.ClientCard;
            if (clientCard is null)
                return new ValidationResult($"'{client.Name}' don't have ClubCard");


            return client.ClientCard.ServiceId != serviceId ? new ValidationResult($"'{client.Name}' don't have necessary ClubCard for this Service") : null;
        }
    }
}
