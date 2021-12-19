﻿using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class CreateResponsibleMapperBL : IMapper<CreateResponsibleDtoBL, Responsible>
    {
        public Responsible Map(CreateResponsibleDtoBL createResponsibleDtoBL)
        {
            return new ()
            {
                Name = createResponsibleDtoBL.Name,
                SerName = createResponsibleDtoBL.SerName,
                Telephone = createResponsibleDtoBL.Telephone,
            };
        }
    }
}