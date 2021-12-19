using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingUI.Models.TrainerUI.Dto;

namespace ServiceAccountingUI.Models.TrainerUI.Mapper
{
    public static class ReadTrainerMapperUI
    {
        public static ResponseGetTrainerDtoUI Map<Result>(GetTrainerDtoBL trainer)
        where Result : ResponseGetTrainerDtoUI
        {
            return new ()
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

        public static ICollection<ResponseGetTrainerDtoUI> Map<Result>(ICollection<GetTrainerDtoBL> trainers)
                where Result : ICollection<ResponseGetTrainerDtoUI>
        {
            return trainers.Select(trainer => Map<ResponseGetTrainerDtoUI>(trainer)).ToList();
        }
    }
}
