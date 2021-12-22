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
            //In AcceptCreateClientCardDtoUI -> DateActivation = DateTime.Now
            return new()
            {
                DateActivation = dto.DateActivation ?? DateTime.Now.ToLocalTime(),
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
                DateActivation = dto.DateActivation.ToLocalTime(),
                DateExpiration = dto.DateExpiration.ToLocalTime()
            };
        }

    }
}
