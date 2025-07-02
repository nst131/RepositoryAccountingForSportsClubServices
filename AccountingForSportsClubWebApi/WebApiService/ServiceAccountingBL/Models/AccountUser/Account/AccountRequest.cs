using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public static class AccountRequest
    {
        public static async Task<ICollection<TrainingToClient>> GetTrainingsToClient(
            int clientId,
            IServiceAccountingContext context)
        {
            return await context.Set<Client>()
                .AsNoTracking()
                .Where(x => x.Id == clientId)
                .Select(x => x.Trainings)
                .FirstOrDefaultAsync();
        }

        public static async Task<Training> GetTraining(
            TrainingToClient trainingToClient,
            IServiceAccountingContext context)
        {
            return await context.Set<Training>()
                .AsNoTracking()
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == trainingToClient.TrainingId);
        }

        public static async Task<ICollection<SubscriptionToClient>> GetSubscriptionToClient(
            int clientId,
            IServiceAccountingContext context)
        {
            return await context.Set<Client>()
                .AsNoTracking()
                .Where(x => x.Id == clientId)
                .Select(x => x.Subscriptions)
                .FirstOrDefaultAsync();
        }

        public static async Task<Subscription> GetSubscription(
            SubscriptionToClient subscriptionToClient,
            IServiceAccountingContext context)
        {
            return await context.Set<Subscription>()
                .AsNoTracking()
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == subscriptionToClient.SubscriptionId);
        }

        public static async Task<ICollection<Visit>> GetVisits(
            int clientId,
            IServiceAccountingContext context)
        {
            return await context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.Visits).ThenInclude(x => x.Service)
                .Where(x => x.Id == clientId)
                .Select(x => x.Visits)
                .FirstOrDefaultAsync();
        }

        public static async Task<ICollection<Deal>> GetDeals(
            int clientId,
            IServiceAccountingContext context)
        {
            return await context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.Deals).ThenInclude(x => x.Subscription)
                .Include(x => x.Deals).ThenInclude(x => x.ClubCard)
                .Where(x => x.Id == clientId)
                .Select(x => x.Deals)
                .FirstOrDefaultAsync();
        }
    }
}
