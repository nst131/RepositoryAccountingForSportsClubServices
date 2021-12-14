using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingDA.Models;
using System.Collections.Generic;

namespace ServiceAccountingBL.TrainerBLL.Mapper
{
    public static class GetTrainerMapperBL
    {
        public static GetTrainerDtoBL Map<Result>(Trainer trainer)
            where Result : GetTrainerDtoBL
        {
            return new GetTrainerDtoBL()
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
            var allClientsDto = new List<GetTrainerDtoBL>();

            foreach (var trainer in allTrainers)
            {
                allClientsDto.Add(Map<GetTrainerDtoBL>(trainer));
            }

            return allClientsDto;
        }
    }
}
