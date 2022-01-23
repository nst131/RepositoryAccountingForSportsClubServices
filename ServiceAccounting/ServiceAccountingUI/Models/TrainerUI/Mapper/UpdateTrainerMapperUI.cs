using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingUI.Models.TrainerUI.Dto;

namespace ServiceAccountingUI.Models.TrainerUI.Mapper
{
    public static class UpdateTrainerMapperUI
    {
        public static AcceptUpdateTrainerDtoBL Map<Result>(AcceptUpdateTrainerDtoUI trainer)
            where Result : AcceptUpdateTrainerDtoBL
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSexId = trainer.TypeSexId,
                ServiceId = trainer.ServiceId
            };
        }

        public static ResponseTrainerDtoUI Map<Result>(ResponseTrainerDtoBL trainer)
            where Result : ResponseTrainerDtoUI
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name
            };
        }
    }
}
