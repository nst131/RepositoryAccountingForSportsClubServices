using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingUI.Models.TrainingUI.Dto;

namespace ServiceAccountingUI.Models.TrainingUI.Mapper
{
    public class ReadTrainingMapperUI
    {
        public static ResponseGetTrainingDtoUI Map<Result>(ResponseGetTrainingDtoBL dto)
            where Result : ResponseGetTrainingDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                FinishTraining = dto.FinishTraining,
                ServiceName = dto.ServiceName,
                TrainerName = dto.TrainerName
            };
        }

        public static ICollection<ResponseGetTrainingDtoUI> Map<Result>(ICollection<ResponseGetTrainingDtoBL> dtos)
            where Result : ICollection<ResponseGetTrainingDtoUI>
        {
            return dtos.Select(dto => Map<ResponseGetTrainingDtoUI>(dto)).ToList();
        }
    }
}
