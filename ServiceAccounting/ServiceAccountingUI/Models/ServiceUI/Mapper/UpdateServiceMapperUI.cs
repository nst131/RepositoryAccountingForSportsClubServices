﻿using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingUI.Models.ServiceUI.Dto;

namespace ServiceAccountingUI.Models.ServiceUI.Mapper
{
    public class UpdateServiceMapperUI
    {
        public static AcceptUpdateServiceDtoBL Map<Result>(AcceptUpdateServiceDtoUI dto)
            where Result : AcceptUpdateServiceDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                DurationInMinutes = dto.DurationInMinutes,
                PlaceId = dto.PlaceId
            };
        }

        public static ResponseServiceDtoUI Map<Result>(ResponseServiceDtoBL dto)
            where Result : ResponseGetServiceDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
