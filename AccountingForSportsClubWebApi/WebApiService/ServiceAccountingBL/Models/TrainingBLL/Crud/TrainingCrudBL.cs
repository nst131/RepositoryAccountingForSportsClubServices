using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Aggregator;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Mapper;
using ServiceAccountingBL.Models.TrainingBLL.Validation;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
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
        private readonly ITrainingAditionalOperation trainingAditionalOperation;
        private readonly ICheckClientCardNecessaryServiceValidation checkClientCardNecessaryService;

        public TrainingCrudBL(
            IServiceAccountingContext context,
            IAggregatorTrainingBL aggregator,
            ITrainingAditionalOperation trainingAditional,
            ICheckClientCardNecessaryServiceValidation checkClientCardNecessaryService)
        {
            this.context = context;
            this.trainingAditionalOperation = trainingAditional;
            this.checkClientCardNecessaryService = checkClientCardNecessaryService;
            this.removeTraining = aggregator.RemoveTraining;
            this.createValidator = aggregator.CreateValidator;
            this.updateValidator = aggregator.UpdateValidator;
            this.getTraining = aggregator.GetTraining;
        }

        public async Task<ResponseTrainingDtoBL> CreateTrainingByClubCard(
            AcceptCreateTrainingDtoBL createTrainingDtoBL, CancellationToken token = default)
        {
            await createValidator.Validate(createTrainingDtoBL);
            var clientsHasExpired = await this.checkClientCardNecessaryService.GetClientsHasExpired(createTrainingDtoBL.ClientsId, createTrainingDtoBL.ServicesId, token);

            var service = await context.Set<Service>()
                .FirstOrDefaultAsync(x => x.Id == createTrainingDtoBL.ServicesId, token);
            var training = CreateTrainingMapperBL.Map<Training>(createTrainingDtoBL);
            training.FinishTraining = createTrainingDtoBL.StartTraining.AddMinutes(service.DurationInMinutes);
            var addedTraining = await context.Set<Training>().AddAsync(training, token);
            await context.SaveChangesAsync(token);

            if (createTrainingDtoBL.ClientsId is not null && createTrainingDtoBL.ClientsId.Any())
            {
                await this.trainingAditionalOperation.AddClientsInTraining(createTrainingDtoBL.ClientsId, addedTraining.Entity.Id);
            }

            var responseTraining = ResponseTrainingMapperBL.Map<ResponseTrainingDtoBL>(addedTraining.Entity);
            responseTraining.ClientsHasExpired = clientsHasExpired;

            return responseTraining;
        }

        public async Task<ResponseTrainingDtoBL> UpdateTrainingByClubCard(AcceptUpdateTrainingDtoBL updateTrainingDtoBL, CancellationToken token = default)
        {
            await updateValidator.Validate(updateTrainingDtoBL);
            var clientsHasExpired = await this.checkClientCardNecessaryService.GetClientsHasExpired(updateTrainingDtoBL.ClientsId, updateTrainingDtoBL.ServicesId, token);

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

            await this.trainingAditionalOperation.UpdateClientsInTraining(updateTrainingDtoBL.ClientsId, updateTrainingDtoBL.Id, token);

            await context.SaveChangesAsync(token);

            var responseTraining = ResponseTrainingMapperBL.Map<ResponseTrainingDtoBL>(training);
            responseTraining.ClientsHasExpired = clientsHasExpired;

            return responseTraining;
        }

        public async Task DeleteTraining(int id, CancellationToken token = default)
            => await removeTraining.Remove(id, token);

        public async Task<ResponseGetTrainingDtoBL> GetTraining(int id, CancellationToken token = default)
            => await getTraining.Get(id, token);
    }
}
