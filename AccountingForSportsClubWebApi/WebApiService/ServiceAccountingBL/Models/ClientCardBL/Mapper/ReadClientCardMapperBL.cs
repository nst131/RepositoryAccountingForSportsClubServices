using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Mapper
{
    public static class ReadClientCardMapperBL
    {
        public static ResponseGetClientCardDtoBL Map<Result>(ClientCard dto)
            where Result : ResponseGetClientCardDtoBL
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                DateExpiration = dto.DateExpiration,
                ServiceName = dto.Service.Name,
                ClubCardName = dto.ClubCard.Name
            };
        }

        public static ICollection<ResponseGetClientCardDtoBL> Map<Result>(ICollection<ClientCard> allClientCards)
            where Result : ICollection<ResponseGetClientCardDtoBL>
        {
            return allClientCards.Select(dto => Map<ResponseGetClientCardDtoBL>(dto)).ToList();
        }
    }
}
