﻿using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingUI.Models.VisitUI.Dto;

namespace ServiceAccountingUI.Models.VisitUI.Mapper
{
    public class UpdateVisitMapperUI
    {
        public static AcceptUpdateVisitDtoBL Map<Result>(AcceptUpdateVisitDtoUI dto)
            where Result : AcceptUpdateVisitDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId
            };
        }

        public static ResponseVisitDtoUI Map<Result>(ResponseVisitDtoBL dto)
            where Result : ResponseGetVisitDtoUI
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
