using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Mapper
{
    public class ReadTrainingMapperBL
    {
        public static ResponseGetTrainingDtoBL Map<Result>(Training dto)
            where Result : ResponseGetTrainingDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                FinishTraining = dto.FinishTraining,
                TrainerName = dto.Trainer.Name, // Load Trainer
                ServiceName = dto.Service.Name // Load Service
            };
        }

        public static ICollection<ResponseGetTrainingDtoBL> Map<Result>(ICollection<Training> allClientCards)
            where Result : ICollection<ResponseGetTrainingDtoBL>
        {
            return allClientCards.Select(dto => Map<ResponseGetTrainingDtoBL>(dto)).ToList();
        }
    }
}