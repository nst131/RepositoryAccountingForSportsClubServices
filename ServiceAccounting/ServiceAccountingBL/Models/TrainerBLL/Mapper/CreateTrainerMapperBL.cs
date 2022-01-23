using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class CreateTrainerMapperBL : IMapper<AcceptCreateTrainerDtoBL, Trainer>
    {
        public Trainer Map(AcceptCreateTrainerDtoBL createTrainerDtoBL)
        {
            return new ()
            {
                Name = createTrainerDtoBL.Name,
                Email = createTrainerDtoBL.Email,
                SerName = String.Empty,
                Telephone = String.Empty,
                TypeSexId = TypeOfSex.NoGender.Id,
                ServiceId = null
            };
        }
    }
}
