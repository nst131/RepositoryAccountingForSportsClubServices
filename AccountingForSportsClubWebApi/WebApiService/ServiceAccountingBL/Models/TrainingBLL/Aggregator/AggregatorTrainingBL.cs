using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Crud;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Aggregator
{
    public class AggregatorTrainingBL : IAggregatorTrainingBL
    {
        private readonly Lazy<ITrainingCrudBL> trainingCrudBL;
        private readonly Lazy<ITrainingFetchersBL> trainingFetchersBL;
        private readonly Lazy<IRemover<Training>> removeTraining;
        private readonly Lazy<IGetter<ResponseGetTrainingDtoBL>> getTraining;
             
        private readonly Lazy<IValidator<AcceptCreateTrainingDtoBL>> createValidator;
        private readonly Lazy<IValidator<AcceptUpdateTrainingDtoBL>> updateValidator;

        public AggregatorTrainingBL(Lazy<ITrainingCrudBL> trainingCrudBL,
            Lazy<ITrainingFetchersBL> trainingFetchersBL,
            Lazy<IRemover<Training>> removeTraining,
            Lazy<IGetter<ResponseGetTrainingDtoBL>> getTraining,
            Lazy<IValidator<AcceptCreateTrainingDtoBL>> createValidator,
            Lazy<IValidator<AcceptUpdateTrainingDtoBL>> updateValidator)
        {
            this.trainingCrudBL = trainingCrudBL;
            this.trainingFetchersBL = trainingFetchersBL;
            this.removeTraining = removeTraining;
            this.getTraining = getTraining;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        public ITrainingCrudBL TrainingCrudBL => trainingCrudBL.Value;
        public ITrainingFetchersBL TrainingFetchersBL => trainingFetchersBL.Value;
        public IRemover<Training> RemoveTraining => removeTraining.Value;
        public IGetter<ResponseGetTrainingDtoBL> GetTraining => getTraining.Value;

        public IValidator<AcceptCreateTrainingDtoBL> CreateValidator => createValidator.Value;
        public IValidator<AcceptUpdateTrainingDtoBL> UpdateValidator => updateValidator.Value;
    }
}
