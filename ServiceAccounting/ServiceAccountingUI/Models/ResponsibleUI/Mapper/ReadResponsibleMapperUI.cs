﻿using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;

namespace ServiceAccountingUI.Models.ResponsibleUI.Mapper
{
    public static class ReadResponsibleMapperUI
    {
        public static ResponseGetResponsibleDtoUI Map<Result>(GetResponsibleDtoBL responsible)
                where Result : ResponseGetResponsibleDtoUI
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ICollection<ResponseGetResponsibleDtoUI> Map<Result>(ICollection<GetResponsibleDtoBL> responsibles)
                where Result : ICollection<ResponseGetResponsibleDtoUI>
        {
            return responsibles.Select(x => Map<ResponseGetResponsibleDtoUI>(x)).ToList();
        }
    }
}
