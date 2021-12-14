using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.TrainerBLL.Aggregator;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingBL.TrainerBLL.Mapper;
using ServiceAccountingBL.TrainerBLL.Validation;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.TrainerBLL.Crud
{
    public class TrainerCrudBL : ITrainerCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ITrainerValidator<CreateTrainerDtoBL> validatorCreate;
        private readonly ITrainerValidator<UpdateTrainerDtoBL> validatorUpdate;

        public TrainerCrudBL(IServiceAccountingContext context, IAggregatorTrainerBL aggregator)
        {
            this.context = context;
            validatorCreate = aggregator.CreateTrainerValidator;
            validatorUpdate = aggregator.UpdateTrainerValidator;
        }

        public async Task<TrainerDtoBL> CreateTrainer(CreateTrainerDtoBL createTrainerDtoBL)
        {
            await validatorCreate.Validate(createTrainerDtoBL);
            var trainer = CreateTrainerMapperBL.Map<Trainer>(createTrainerDtoBL);
            var addedTrainer = await context.Set<Trainer>().AddAsync(trainer);
            await context.SaveChangesAsync();

            return TrainerMapperBL.Map<TrainerDtoBL>(addedTrainer.Entity);
        }

        public async Task<TrainerDtoBL> UpdateTrainer(UpdateTrainerDtoBL updateTrainerDtoBL)
        {
            await validatorUpdate.Validate(updateTrainerDtoBL);
            var trainer = UpdateTrainerMapperBL.Map<Trainer>(updateTrainerDtoBL);
            var updatedTrainer = await Task.Factory.StartNew(() => context.Set<Trainer>().Update(trainer));
            await context.SaveChangesAsync();

            return TrainerMapperBL.Map<TrainerDtoBL>(updatedTrainer.Entity);
        }

        public async Task DeleteTrainer(int id)
        {
            try
            {
                var trainer = await context.Set<Trainer>().FirstOrDefaultAsync(x => x.Id == id);
                await Task.Factory.StartNew(() => context.Set<Trainer>().Remove(trainer));
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");
            }
        }

        public async Task<GetTrainerDtoBL> GetTrainer(int id)
        {
            try
            {
                var trainer = await context.Set<Trainer>()
                    .Include(x => x.TypeSex)
                    .Include(x => x.Service)
                    .FirstOrDefaultAsync(x => x.Id == id);
                return GetTrainerMapperBL.Map<GetTrainerDtoBL>(trainer);
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Trainer)} by Id not Found");
            }
        }

        public async Task<ICollection<GetTrainerDtoBL>> GetTrainerAll()
        {
            if (await context.Set<Trainer>().AnyAsync())
            {
                var allTrainers = await context.Set<Trainer>()
                    .Include(x => x.TypeSex)
                    .Include(x => x.Service)
                    .ToListAsync();

                return GetTrainerMapperBL.Map<ICollection<GetTrainerDtoBL>>(allTrainers);
            }

            return new List<GetTrainerDtoBL>();
        }
    }
}
