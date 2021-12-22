using System;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingUI.Models.VisitUI.Dto;

namespace ServiceAccountingUI.Models.VisitUI.Mapper
{
    public static class CreateVisitMapperUI
    {
        public static AcceptCreateVisitDtoBL Map<Result>(AcceptCreateVisitDtoUI dto)
            where Result : AcceptCreateVisitDtoBL
        {
            return new()
            {
                Arrival = dto.Arrival ?? DateTime.Now.ToLocalTime(),
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId
            };
        }

        public static ResponseVisitDtoUI Map<Result>(ResponseVisitDtoBL dto)
            where Result : ResponseVisitDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Arrival = dto.Arrival.ToLocalTime(),
                ClientName = dto.ClientName
            };
        }
    }


}
