using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class CreateTrainerMapperBL : IMapper<CreateTrainerDtoBL, Trainer>
    {
        public Trainer Map(CreateTrainerDtoBL createTrainerDtoBL)
        {
            return new ()
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
