using System.Threading;
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

        public async Task<ResponseTrainerDtoBL> CreateTrainer(AcceptCreateTrainerDtoBL createTrainerDtoBL, CancellationToken token = default)
            => await createTrainer.Create(createTrainerDtoBL, token);

        public async Task<ResponseTrainerDtoBL> UpdateTrainer(AcceptUpdateTrainerDtoBL updateTrainerDtoBL, CancellationToken token = default)
            => await updateTrainer.Update(updateTrainerDtoBL, token);

        public async Task DeleteTrainer(int id, CancellationToken token = default)
            => await removeTrainer.Remove(id, token);

        public async Task<ResponseGetTrainerDtoBL> GetTrainer(int id, CancellationToken token = default)
            => await getTrainer.Get(id, token);
    }
}
