using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Crud
{
    public class TrainerCrudBL : ITrainerCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL> createTrainer;
        private readonly IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL> updateTrainer;
        private readonly IRemover<Trainer> removeTrainer;

        public TrainerCrudBL(IServiceAccountingContext context, IAggregatorTrainerBL aggregator)
        {
            this.context = context;
            this.createTrainer = aggregator.CreateTrainer;
            this.updateTrainer = aggregator.UpdateTrainer;
            this.removeTrainer = aggregator.RemoveTrainer;
        }

        public async Task<ResponseTrainerDtoBL> CreateTrainer(AcceptCreateTrainerDtoBL createTrainerDtoBL)
        {
            return await createTrainer.Create(createTrainerDtoBL);
        }

        public async Task<ResponseTrainerDtoBL> UpdateTrainer(AcceptUpdateTrainerDtoBL updateTrainerDtoBL)
        {
            return await updateTrainer.Update(updateTrainerDtoBL);
        }

        public async Task DeleteTrainer(int id)
        {
            await removeTrainer.Remove(id);
        }

        public async Task<ResponseGetTrainerDtoBL> GetTrainer(int id)
        {
            if(id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Trainer)} is less 0");

            var trainer = await context.Set<Trainer>()
                    .Include(x => x.TypeSex)
                    .Include(x => x.Service)
                    .FirstOrDefaultAsync(x => x.Id == id);
            if(trainer is null)
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");

            return ReadTrainerMapperBL.Map<ResponseGetTrainerDtoBL>(trainer);
        }
    }
}
