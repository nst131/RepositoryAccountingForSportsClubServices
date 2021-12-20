using System;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingUI.Models.ClientCardUI.Dto;

namespace ServiceAccountingUI.Models.ClientCardUI.Mapper
{
    public class CreateClientCardMapperUI
    {
        public static AcceptCreateClientCardDtoBL Map<Result>(AcceptCreateClientCardDtoUI dto)
            where Result : AcceptCreateClientCardDtoBL
        {
            return new()
            {
                DateActivation = dto.DateActivation,
                ClientId = dto.ClientId,
                ClubCardId = dto.ClubCardId
            };
        }

        public static ResponseClientCardDtoUI Map<Result>(ResponseClientCardDtoBL dto)
            where Result : ResponseClientCardDtoUI
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
