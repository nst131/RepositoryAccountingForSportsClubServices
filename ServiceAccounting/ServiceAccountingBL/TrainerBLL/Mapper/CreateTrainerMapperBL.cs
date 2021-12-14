using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.TrainerBLL.Mapper
{
    public static class CreateTrainerMapperBL
    {
        public static Trainer Map<Result>(CreateTrainerDtoBL createTrainerDtoBL)
            where Result : Trainer
        {
            return new Trainer()
            {
                Name = createTrainerDtoBL.Name,
                SerName = createTrainerDtoBL.SerName,
                Telephone = createTrainerDtoBL.Telephone,
                TypeSexId = createTrainerDtoBL.TypeSexId,
                ServiceId = createTrainerDtoBL.ServiceId
            };
        }
    }
}
