﻿using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingUI.Models.ClientCardUI.Dto;

namespace ServiceAccountingUI.Models.ClientCardUI.Mapper
{
    public class UpdateClientCardMapperUI
    {
        public static AcceptUpdateClientCardDtoBL Map<Result>(AcceptUpdateClientCardDtoUI dto)
            where Result : AcceptUpdateClientCardDtoBL
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                ClientId = dto.ClientId,
                ClubCardId = dto.ClubCardId
            };
        }

        public static ResponseClientCardDtoUI Map<Result>(ResponseClientCardDtoBL dto)
            where Result : ResponseGetClientCardDtoUI
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                DateExpiration = dto.DateExpiration
            };
        }
    }
}
