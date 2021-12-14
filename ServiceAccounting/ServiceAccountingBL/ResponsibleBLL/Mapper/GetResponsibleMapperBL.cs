using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;
using System.Collections.Generic;

namespace ServiceAccountingBL.ResponsibleBLL.Mapper
{
    public static class GetResponsibleMapperBL
    {
        public static GetResponsibleDtoBL Map<Result>(Responsible responsible)
            where Result : GetResponsibleDtoBL
        {
            return new GetResponsibleDtoBL()
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
            var allResponsiblesDto = new List<GetResponsibleDtoBL>();

            foreach (var responsible in allResponsibles)
            {
                allResponsiblesDto.Add(Map<GetResponsibleDtoBL>(responsible));
            }

            return allResponsiblesDto;
        }
    }
}
