using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Aggregator
{
    public class AggregatorTrainerBL : IAggregatorTrainerBL
    {
        private readonly Lazy<ITrainerCrudBL> trainerCrudBL;
        private readonly Lazy<ITrainerFetchersBL> trainerFetchersBL;
        private readonly Lazy<ICreater<CreateTrainerDtoBL, TrainerDtoBL>> createTrainer;
        private readonly Lazy<IUpdater<UpdateTrainerDtoBL, TrainerDtoBL>> updateTrainer;
        private readonly Lazy<IRemover<Trainer>> removeTrainer;

        public AggregatorTrainerBL(Lazy<ITrainerCrudBL> trainerCrudBL,
            Lazy<ITrainerFetchersBL> trainerFetchersBL,
            Lazy<ICreater<CreateTrainerDtoBL, TrainerDtoBL>> createTrainer,
            Lazy<IUpdater<UpdateTrainerDtoBL, TrainerDtoBL>> updateTrainer,
            Lazy<IRemover<Trainer>> removeTrainer)
        {
            this.trainerCrudBL = trainerCrudBL;
            this.trainerFetchersBL = trainerFetchersBL;
            this.createTrainer = createTrainer;
            this.updateTrainer = updateTrainer;
            this.removeTrainer = removeTrainer;
        }

        public ITrainerCrudBL TrainerCrudBL => trainerCrudBL.Value;
        public ITrainerFetchersBL TrainerFetchersBL => trainerFetchersBL.Value;
        public ICreater<CreateTrainerDtoBL, TrainerDtoBL> CreateTrainer => createTrainer.Value;
        public IUpdater<UpdateTrainerDtoBL, TrainerDtoBL> UpdateTrainer => updateTrainer.Value;
        public IRemover<Trainer> RemoveTrainer => removeTrainer.Value;
    }
}
