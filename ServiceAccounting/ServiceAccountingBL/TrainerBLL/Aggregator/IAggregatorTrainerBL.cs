using ServiceAccountingBL.TrainerBLL.Crud;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingBL.TrainerBLL.Validation;

namespace ServiceAccountingBL.TrainerBLL.Aggregator
{
    public interface IAggregatorTrainerBL
    {
        ITrainerCrudBL TrainerCrudBL { get; }
        ITrainerValidator<CreateTrainerDtoBL> CreateTrainerValidator { get; }
        ITrainerValidator<UpdateTrainerDtoBL> UpdateTrainerValidator { get; }
    }
}