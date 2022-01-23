using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Mapper
{
    public static class UpdateTrainingMapperBL
    {
        public static Training Map<Result>(AcceptUpdateTrainingDtoBL dto)
            where Result : Training
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                ServicesId = dto.ServicesId,
                TrainerId = dto.TrainerId,
            };
        }
    }
}
