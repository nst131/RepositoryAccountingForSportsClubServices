using System;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingUI.Models.TrainingUI.Dto;

namespace ServiceAccountingUI.Models.TrainingUI.Mapper
{
    public class UpdateTrainingMapperUI
    {
        public static AcceptUpdateTrainingDtoBL Map<Result>(AcceptUpdateTrainingDtoUI dto)
            where Result : AcceptUpdateTrainingDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining ?? DateTime.Now.ToLocalTime(),
                TrainerId = dto.TrainerId,
                ServicesId = dto.ServicesId,
                ClientsId = dto.ClientsId
            };
        }

        public static ResponseTrainingDtoUI Map<Result>(ResponseTrainingDtoBL dto)
            where Result : ResponseTrainingDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                ClientsHasExpired = dto.ClientsHasExpired
            };
        }
    }
}
