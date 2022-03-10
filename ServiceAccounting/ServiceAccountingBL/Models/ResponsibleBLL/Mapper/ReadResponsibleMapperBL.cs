using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public static class ReadResponsibleMapperBL
    {
        public static ResponseGetResponsibleDtoBL Map<Result>(Responsible responsible)
            where Result : ResponseGetResponsibleDtoBL
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
                Email = responsible.Email
            };
        }

        public static ICollection<ResponseGetResponsibleDtoBL> Map<Result>(ICollection<Responsible> allResponsibles)
             where Result : ICollection<ResponseGetResponsibleDtoBL>
        {
            return allResponsibles.Select(responsible => Map<ResponseGetResponsibleDtoBL>(responsible)).ToList();
        }
    }
}
