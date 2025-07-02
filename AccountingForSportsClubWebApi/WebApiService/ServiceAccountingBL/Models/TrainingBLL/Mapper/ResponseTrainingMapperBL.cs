using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Mapper
{
    public class ResponseTrainingMapperBL
    {
        public static ResponseTrainingDtoBL Map<Result>(Training dto)
            where Result : ResponseTrainingDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining
            };
        }
    }
}