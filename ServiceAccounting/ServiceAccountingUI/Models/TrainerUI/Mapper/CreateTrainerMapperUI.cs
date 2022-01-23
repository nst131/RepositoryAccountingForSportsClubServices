using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingUI.Models.TrainerUI.Dto;

namespace ServiceAccountingUI.Models.TrainerUI.Mapper
{
    public static class CreateTrainerMapperUI
    {
        public static AcceptCreateTrainerDtoBL Map<Result>(AcceptCreateTrainerDtoUI trainer)
            where Result : AcceptCreateTrainerDtoBL
        {
            return new ()
            {
                Name = trainer.Name,
                Email = trainer.Email
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
