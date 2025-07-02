using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public static class ReadVisitMapperBL
    {
        public static ResponseGetVisitDtoBL Map<Result>(Visit dto)
            where Result: ResponseGetVisitDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ClientName = dto.Client.Name,
                ServiceName = dto.Service.Name
            };
        }

        public static ICollection<ResponseGetVisitDtoBL> Map<Result>(ICollection<Visit> allDto)
            where Result : ICollection<ResponseGetVisitDtoBL>
        {
            return allDto.Select(x => Map<ResponseGetVisitDtoBL>(x)).ToList();
        }
    }
}