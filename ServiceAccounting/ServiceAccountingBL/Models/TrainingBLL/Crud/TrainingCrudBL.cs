using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Aggregator;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public class TrainingCrudBL : ITrainingCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IValidator<AcceptCreateTrainingDtoBL> createValidator;
        private readonly IValidator<AcceptUpdateTrainingDtoBL> updateValidator;
        private readonly IRemover<Training> removeTraining;
        private readonly IGetter<ResponseGetTrainingDtoBL> getTraining;

        public TrainingCrudBL(IServiceAccountingContext context, IAggregatorTrainingBL aggregator)
        {
            this.context = context;
            this.removeTraining = aggregator.RemoveTraining;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getTraining = aggregator.GetTraining;
        }

        public async Task<ResponseTrainingDtoBL> CreateTraining(AcceptCreateTrainingDtoBL createTrainingDtoBL, CancellationToken token = default)
        {
            await createValidator.Validate(createTrainingDtoBL);

            var service = await context.Set<Service>().FirstOrDefaultAsync(x => x.Id == createTrainingDtoBL.ServicesId, token);
            var training = CreateTrainingMapperBL.Map<Training>(createTrainingDtoBL);
            training.FinishTraining = createTrainingDtoBL.StartTraining.AddMinutes(service.DurationInMinutes);
            var addedTraining = await context.Set<Training>().AddAsync(training, token);
            await context.SaveChangesAsync(token);

            if (createTrainingDtoBL.ClientsId is not null && createTrainingDtoBL.ClientsId.Any())
            {
                await AddClientsInTraining(createTrainingDtoBL.ClientsId, addedTraining.Entity.Id);
            }

            return ResponseTrainingMapperBL.Map<ResponseTrainingDtoBL>(addedTraining.Entity);
        }

        private async Task AddClientsInTraining(IEnumerable<int> clientsId, int trainingId)
        {
            var trainingToClients = clientsId
                .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

            await context.Set<TrainingToClient>().AddRangeAsync(trainingToClients);
            await context.SaveChangesAsync();
        }

        public async Task<ResponseTrainingDtoBL> UpdateTraining(AcceptUpdateTrainingDtoBL updateTrainingDtoBL, CancellationToken token = default)
        {
            await updateValidator.Validate(updateTrainingDtoBL);
            var service = await context.Set<Service>().FirstOrDefaultAsync(x => x.Id == updateTrainingDtoBL.ServicesId, token);
            var training = UpdateTrainingMapperBL.Map<Training>(updateTrainingDtoBL);
            training.FinishTraining = updateTrainingDtoBL.StartTraining.AddMinutes(service.DurationInMinutes);
            await Task.Factory.StartNew(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                return context.Set<Training>().Update(training);

            }, token);
            await UpdateClientsInTraining(updateTrainingDtoBL.ClientsId, updateTrainingDtoBL.Id, token);

            await context.SaveChangesAsync(token);

            return ResponseTrainingMapperBL.Map<ResponseTrainingDtoBL>(training);
        }

        private async Task UpdateClientsInTraining(IEnumerable<int> clientsId, int trainingId, CancellationToken token = default)
        {
            var currentClientsIdByTrainingId = await context.Set<TrainingToClient>()
                .AsNoTracking()
                .Where(x => x.TrainingId == trainingId)
                .Select(x => x.ClientId)
                .ToListAsync(token);

            var t1 = Task.Run(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                AddClientsInTraining(clientsId, trainingId, currentClientsIdByTrainingId);
            }, token);
            var t2 = Task.Run(() =>
            {
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }

                RemoveClientsInTraining(clientsId, trainingId, currentClientsIdByTrainingId);
            }, token);

            await Task.WhenAll(t1, t2);
        }

        private async void AddClientsInTraining(IEnumerable<int> clientsId, int trainingId, IEnumerable<int> currentClientsId)
        {
            var clientsIdToAdd = clientsId.Except(currentClientsId).ToList();
            if (clientsIdToAdd.Any())
            {
                var trainingToClients = clientsIdToAdd
                    .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

                await context.Set<TrainingToClient>().AddRangeAsync(trainingToClients);
            }
        }

        private async void RemoveClientsInTraining(IEnumerable<int> clientsId, int trainingId, IEnumerable<int> currentClientsId)
        {
            var clientsIdToRemove = currentClientsId.Except(clientsId).ToList();
            if (clientsIdToRemove.Any())
            {
                var trainingToClients = clientsIdToRemove
                    .Select(clientId => new TrainingToClient() { TrainingId = trainingId, ClientId = clientId }).ToList();

                await Task.Factory.StartNew(() => context.Set<TrainingToClient>().RemoveRange(trainingToClients));
            }
        }

        public async Task DeleteTraining(int id, CancellationToken token = default)
            => await removeTraining.Remove(id, token);

        public async Task<ResponseGetTrainingDtoBL> GetTraining(int id, CancellationToken token = default)
            => await getTraining.Get(id, token);
    }
}
