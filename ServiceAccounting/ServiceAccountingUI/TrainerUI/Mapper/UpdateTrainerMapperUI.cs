using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingUI.TrainerUI.Dto;

namespace ServiceAccountingUI.TrainerUI.Mapper
{
    public static class UpdateTrainerMapperUI
    {
        public static UpdateTrainerDtoBL Map<Result>(UpdateTrainerDtoUI trainer)
            where Result : UpdateTrainerDtoBL
        {
            return new UpdateTrainerDtoBL()
            {
                Id = trainer.Id,
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
