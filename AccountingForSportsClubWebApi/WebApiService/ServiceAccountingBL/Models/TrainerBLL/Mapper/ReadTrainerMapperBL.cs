using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public static class ReadTrainerMapperBL
    {
        public static ResponseGetTrainerDtoBL Map<Result>(Trainer trainer)
            where Result : ResponseGetTrainerDtoBL
        {
            return new ()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSex = trainer.TypeSex.Name,
                ServiceId = trainer.ServiceId ?? 0,
                Service = trainer.Service?.Name ?? "Not assigned",
                Email = trainer.Email
            };
        }

        public static ICollection<ResponseGetTrainerDtoBL> Map<Result>(ICollection<Trainer> allTrainers)
             where Result : ICollection<ResponseGetTrainerDtoBL>
        {
            return allTrainers.Select(trainer => Map<ResponseGetTrainerDtoBL>(trainer)).ToList();
        }
    }
}
