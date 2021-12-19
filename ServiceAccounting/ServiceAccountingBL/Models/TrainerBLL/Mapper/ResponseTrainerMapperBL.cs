using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class ResponseTrainerMapperBL : IMapper<Trainer, TrainerDtoBL>
    {
        public TrainerDtoBL Map(Trainer trainer)
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
            };
        }
    }
}
