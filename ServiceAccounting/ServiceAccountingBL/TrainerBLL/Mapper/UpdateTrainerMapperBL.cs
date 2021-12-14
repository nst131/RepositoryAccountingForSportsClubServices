using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.TrainerBLL.Mapper
{
    public static class UpdateTrainerMapperBL
    {
        public static Trainer Map<Result>(UpdateTrainerDtoBL updateTrainerDtoBL)
        where Result : Trainer
        {
            return new Trainer()
            {
                Id = updateTrainerDtoBL.Id,
                Name = updateTrainerDtoBL.Name,
                SerName = updateTrainerDtoBL.SerName,
                Telephone = updateTrainerDtoBL.Telephone,
                TypeSexId = updateTrainerDtoBL.TypeSexId,
                ServiceId = updateTrainerDtoBL.ServiceId
            };
        }
    }
}
