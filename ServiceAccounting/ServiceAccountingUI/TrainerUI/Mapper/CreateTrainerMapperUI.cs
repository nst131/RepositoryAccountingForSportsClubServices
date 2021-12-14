using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingUI.TrainerUI.Dto;

namespace ServiceAccountingUI.TrainerUI.Mapper
{
    public static class CreateTrainerMapperUI
    {
        public static CreateTrainerDtoBL Map<Result>(CreateTrainerDtoUI trainer)
            where Result : CreateTrainerDtoBL
        {
            return new CreateTrainerDtoBL()
            {
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSexId = trainer.TypeSexId,
                ServiceId = trainer.ServiceId
            };
        }

        public static TrainerDtoUI Map<Result>(TrainerDtoBL trainer)
            where Result : TrainerDtoUI
        {
            return new TrainerDtoUI()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName
            };
        }
    }
}
