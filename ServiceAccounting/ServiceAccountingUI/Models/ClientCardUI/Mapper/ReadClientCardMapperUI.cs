using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingUI.Models.ClientCardUI.Dto;

namespace ServiceAccountingUI.Models.ClientCardUI.Mapper
{
    public class ReadClientCardMapperUI
    {
        public static ResponseGetClientCardDtoUI Map<Result>(ResponseGetClientCardDtoBL dto)
            where Result : ResponseGetClientCardDtoUI
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation.ToLocalTime(),
                DateExpiration = dto.DateExpiration.ToLocalTime(),
                ServiceName = dto.ServiceName,
                ClubCardName = dto.ClubCardName
            };
        }

        public static ICollection<ResponseGetClientCardDtoUI> Map<Result>(ICollection<ResponseGetClientCardDtoBL> dto)
            where Result : ICollection<ResponseGetClientCardDtoUI>
        {
            return dto.Select(client => Map<ResponseGetClientCardDtoUI>(client)).ToList();
        }
    }
}
