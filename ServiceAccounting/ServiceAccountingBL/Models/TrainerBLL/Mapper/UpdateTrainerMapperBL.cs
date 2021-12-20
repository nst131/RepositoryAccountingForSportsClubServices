using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class UpdateTrainerMapperBL : IMapper<AcceptUpdateTrainerDtoBL, Trainer>
    {
        public Trainer Map(AcceptUpdateTrainerDtoBL updateTrainerDtoBL)
        {
            return new ()
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
