using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingUI.Models.TrainerUI.Dto;

namespace ServiceAccountingUI.Models.TrainerUI.Mapper
{
    public static class CreateTrainerMapperUI
    {
        public static CreateTrainerDtoBL Map<Result>(AcceptCreateTrainerDtoUI trainer)
            where Result : CreateTrainerDtoBL
        {
            return new ()
            {
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSexId = trainer.TypeSexId,
                ServiceId = trainer.ServiceId
            };
        }

        public static ResponseTrainerDtoUI Map<Result>(TrainerDtoBL trainer)
            where Result : ResponseTrainerDtoUI
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName
            };
        }
    }
}
