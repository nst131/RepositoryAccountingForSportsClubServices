using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Crud;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Aggregator
{
    public interface IAggregatorTrainingBL
    {
        ITrainingCrudBL TrainingCrudBL { get; }
        ITrainingFetchersBL TrainingFetchersBL { get; }
        IRemover<Training> RemoveTraining { get; }
        IValidator<AcceptCreateTrainingDtoBL> CreateValidator { get; }
        IValidator<AcceptUpdateTrainingDtoBL> UpdateValidator { get; }
        IGetter<ResponseGetTrainingDtoBL> GetTraining { get; }
    }
}