using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public static class ReadTrainerMapperBL
    {
        public static GetTrainerDtoBL Map<Result>(Trainer trainer)
            where Result : GetTrainerDtoBL
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSex = trainer.TypeSex.Name,
                ServiceId = trainer.ServiceId,
                Service = trainer.Service.Name
            };
        }

        public static ICollection<GetTrainerDtoBL> Map<Result>(ICollection<Trainer> allTrainers)
             where Result : ICollection<GetTrainerDtoBL>
        {
            return allTrainers.Select(trainer => Map<GetTrainerDtoBL>(trainer)).ToList();
        }
    }
}
