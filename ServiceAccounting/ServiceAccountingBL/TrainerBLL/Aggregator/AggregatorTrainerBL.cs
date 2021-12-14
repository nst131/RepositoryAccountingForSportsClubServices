using ServiceAccountingBL.TrainerBLL.Crud;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingBL.TrainerBLL.Validation;
using System;

namespace ServiceAccountingBL.TrainerBLL.Aggregator
{
    public class AggregatorTrainerBL : IAggregatorTrainerBL
    {
        private readonly Lazy<ITrainerCrudBL> trainerCrudBL;
        private readonly Lazy<ITrainerValidator<CreateTrainerDtoBL>> createTrainerValidator;
        private readonly Lazy<ITrainerValidator<UpdateTrainerDtoBL>> updateTrainerValidator;

        public AggregatorTrainerBL(Lazy<ITrainerCrudBL> trainerCrudBL,
            Lazy<ITrainerValidator<CreateTrainerDtoBL>> createTrainerValidator,
            Lazy<ITrainerValidator<UpdateTrainerDtoBL>> updateTrainerValidator)
        {
            this.trainerCrudBL = trainerCrudBL;
            this.createTrainerValidator = createTrainerValidator;
            this.updateTrainerValidator = updateTrainerValidator;
        }

        public ITrainerCrudBL TrainerCrudBL => trainerCrudBL.Value;
        public ITrainerValidator<CreateTrainerDtoBL> CreateTrainerValidator => createTrainerValidator.Value;
        public ITrainerValidator<UpdateTrainerDtoBL> UpdateTrainerValidator => updateTrainerValidator.Value;
    }
}
