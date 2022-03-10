using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public class TrainingAditionalOperation : ITrainingAditionalOperation
    {
        private readonly IServiceAccountingContext context;

        public TrainingAditionalOperation(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task AddClientsInTraining(ICollection<int> clientsId, int trainingId)
        {
            var trainingToClients = clientsId
                .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

            await context.Set<TrainingToClient>().AddRangeAsync(trainingToClients);
            await context.SaveChangesAsync();
        }

        public async Task UpdateClientsInTraining(ICollection<int> clientsId, int trainingId, CancellationToken token = default)
        {
            var currentClientsIdByTrainingId = await context.Set<TrainingToClient>()
                .AsNoTracking()
                .Where(x => x.TrainingId == trainingId)
                .Select(x => x.ClientId)
                .ToListAsync(token);

            var clientsIdToAdd = clientsId.Except(currentClientsIdByTrainingId).ToList();
            if (clientsIdToAdd.Any())
            {
                var trainingToClients = clientsIdToAdd
                    .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

                await context.Set<TrainingToClient>().AddRangeAsync(trainingToClients, token);
            }

            var clientsIdToRemove = currentClientsIdByTrainingId.Except(clientsId).ToList();
            if (clientsIdToRemove.Any())
            {
                var trainingToClients = clientsIdToRemove
                    .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

                await Task.Factory.StartNew(() => context.Set<TrainingToClient>().RemoveRange(trainingToClients), token);
            }
        }
    }
}
