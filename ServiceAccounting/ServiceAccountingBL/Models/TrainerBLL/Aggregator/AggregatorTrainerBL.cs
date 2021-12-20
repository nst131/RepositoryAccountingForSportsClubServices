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
        private readonly Lazy<ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>> createTrainer;
        private readonly Lazy<IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>> updateTrainer;
        private readonly Lazy<IRemover<Trainer>> removeTrainer;

        public AggregatorTrainerBL(Lazy<ITrainerCrudBL> trainerCrudBL,
            Lazy<ITrainerFetchersBL> trainerFetchersBL,
            Lazy<ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>> createTrainer,
            Lazy<IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>> updateTrainer,
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
        public ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL> CreateTrainer => createTrainer.Value;
        public IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL> UpdateTrainer => updateTrainer.Value;
        public IRemover<Trainer> RemoveTrainer => removeTrainer.Value;
    }
}
