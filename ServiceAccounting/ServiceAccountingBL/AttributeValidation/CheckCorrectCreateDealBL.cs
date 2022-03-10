using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.AttributeValidation
{
    public class CheckCorrectCreateDealBL : ICheckCorrectCreateDealBL
    {
        private readonly IServiceAccountingContext context;

        public CheckCorrectCreateDealBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ValidationResult> ValidateCreateDeal(int clientId, int? clubCardId, int? subscriptionId)
        {
            var client = await this.context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.ClientCard)
                .Include(x => x.Subscriptions)
                .FirstOrDefaultAsync(x => x.Id == clientId);

            if (clubCardId is not null)
            {
                if (client.ClientCard is not null)
                    return new ValidationResult("Client has have ClubCard yet");
            }

            if (subscriptionId is not null)
            {
                var subscritions = await Task.Factory
                    .StartNew(() => client.Subscriptions
                        .FirstOrDefault(x => x.SubscriptionId == subscriptionId));

                if (subscritions is not null)
                    return new ValidationResult("Client has have the same Subscription yet");
            }

            return null;
        }
    }
}
