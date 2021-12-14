using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.TrainerBLL.Mapper
{
    public static class TrainerMapperBL
    {
        public static TrainerDtoBL Map<Result>(Trainer trainer)
            where Result : TrainerDtoBL
        {
            return new TrainerDtoBL()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
            };
        }
    }
}
