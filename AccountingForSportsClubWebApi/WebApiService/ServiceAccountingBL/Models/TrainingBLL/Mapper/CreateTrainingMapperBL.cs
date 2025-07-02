using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Mapper
{
    public class CreateTrainingMapperBL
    {
        public static Training Map<Result>(AcceptCreateTrainingDtoBL dto)
            where Result : Training
        {
            return new()
            {
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                TrainerId = dto.TrainerId,
                ServicesId = dto.ServicesId
            };
        }
    }
}
