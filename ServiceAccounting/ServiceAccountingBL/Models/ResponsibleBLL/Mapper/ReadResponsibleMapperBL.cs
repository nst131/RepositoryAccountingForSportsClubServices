using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public static class ReadResponsibleMapperBL
    {
        public static GetResponsibleDtoBL Map<Result>(Responsible responsible)
            where Result : GetResponsibleDtoBL
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ICollection<GetResponsibleDtoBL> Map<Result>(ICollection<Responsible> allResponsibles)
             where Result : ICollection<GetResponsibleDtoBL>
        {
            return allResponsibles.Select(responsible => Map<GetResponsibleDtoBL>(responsible)).ToList();
        }
    }
}
