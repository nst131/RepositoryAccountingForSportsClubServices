using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingUI.Models.VisitUI.Dto;

namespace ServiceAccountingUI.Models.VisitUI.Mapper
{
    public static class ReadVisitMapperUI
    {
        public static ResponseGetVisitDtoUI Map<Result>(ResponseGetVisitDtoBL dto)
            where Result : ResponseGetVisitDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Arrival = dto.Arrival.ToLocalTime(),
                ClientName = dto.ClientName,
                ServiceName = dto.ServiceName
            };
        }

        public static ICollection<ResponseGetVisitDtoUI> Map<Result>(ICollection<ResponseGetVisitDtoBL> dtos)
            where Result : ICollection<ResponseGetVisitDtoUI>
        {
            return dtos.Select(dto => Map<ResponseGetVisitDtoUI>(dto)).ToList();
        }
    }
}
