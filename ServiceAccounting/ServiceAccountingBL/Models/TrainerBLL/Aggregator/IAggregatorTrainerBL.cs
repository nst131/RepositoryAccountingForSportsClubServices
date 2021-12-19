using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Aggregator
{
    public interface IAggregatorTrainerBL
    {
        ITrainerCrudBL TrainerCrudBL { get; }
        ITrainerFetchersBL TrainerFetchersBL { get; }
        ICreater<CreateTrainerDtoBL, TrainerDtoBL> CreateTrainer { get; }
        IUpdater<UpdateTrainerDtoBL, TrainerDtoBL> UpdateTrainer { get; }
        IRemover<Trainer> RemoveTrainer { get; }
    }
}