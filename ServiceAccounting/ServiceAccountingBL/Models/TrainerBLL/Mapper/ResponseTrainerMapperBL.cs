using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class ResponseTrainerMapperBL : IMapper<Trainer, ResponseTrainerDtoBL>
    {
        public ResponseTrainerDtoBL Map(Trainer trainer)
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
