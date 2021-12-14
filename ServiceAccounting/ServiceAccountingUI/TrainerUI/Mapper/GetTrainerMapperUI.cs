using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingUI.TrainerUI.Dto;
using System.Collections.Generic;

namespace ServiceAccountingUI.TrainerUI.Mapper
{
    public static class GetTrainerMapperUI
    {
        public static GetTrainerDtoUI Map<Result>(GetTrainerDtoBL trainer)
        where Result : GetTrainerDtoUI
        {
            return new GetTrainerDtoUI()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                SerName = trainer.SerName,
                Telephone = trainer.Telephone,
                TypeSex = trainer.TypeSex,
                Service = trainer.Service,
                ServiceId = trainer.ServiceId
            };
        }

        public static ICollection<GetTrainerDtoUI> Map<Result>(ICollection<GetTrainerDtoBL> trainers)
                where Result : ICollection<GetTrainerDtoUI>
        {
            var trainersDtoUI = new List<GetTrainerDtoUI>();

            foreach (var trainer in trainers)
            {
                trainersDtoUI.Add(Map<GetTrainerDtoUI>(trainer));
            }

            return trainersDtoUI;
        }
    }
}
