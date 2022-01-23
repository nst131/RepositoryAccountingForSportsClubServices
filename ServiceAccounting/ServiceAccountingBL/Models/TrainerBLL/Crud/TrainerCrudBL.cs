using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.TrainerBLL.Crud
{
    public class TrainerCrudBL : ITrainerCrudBL
    {
        private readonly ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL> createTrainer;
        private readonly IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL> updateTrainer;
        private readonly IRemover<Trainer> removeTrainer;
        private readonly IGetter<ResponseGetTrainerDtoBL> getTrainer;

        public TrainerCrudBL(IAggregatorTrainerBL aggregator)
        {
            this.createTrainer = aggregator.CreateTrainer;
            this.updateTrainer = aggregator.UpdateTrainer;
            this.removeTrainer = aggregator.RemoveTrainer;
            this.getTrainer = aggregator.GetTrainer;
        }

        public async Task<ResponseTrainerDtoBL> CreateTrainer(AcceptCreateTrainerDtoBL createTrainerDtoBL)
            => await createTrainer.Create(createTrainerDtoBL);

        public async Task<ResponseTrainerDtoBL> UpdateTrainer(AcceptUpdateTrainerDtoBL updateTrainerDtoBL)
            => await updateTrainer.Update(updateTrainerDtoBL);

        public async Task DeleteTrainer(int id)
            => await removeTrainer.Remove(id);

        public async Task<ResponseGetTrainerDtoBL> GetTrainer(int id)
            => await getTrainer.Get(id);
    }
}
