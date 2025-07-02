using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingUI.Models.ClubCardUI.Dto;

namespace ServiceAccountingUI.Models.ClubCardUI.Mapper
{
    public static class ReadClubCardMapperUI
    {
        public static ResponseGetClubCardDtoUI Map<Result>(ResponseGetClubCardDtoBL clubCard)
            where Result : ResponseGetClubCardDtoUI
        {
            return new ()
            {
                Id = clubCard.Id,
                Name = clubCard.Name,
                Price = clubCard.Price.ToString(),
                DurationInDays = clubCard.DurationInDays.ToString(),
                Service = clubCard.Service
            };
        }

        public static ICollection<ResponseGetClubCardDtoUI> Map<Result>(ICollection<ResponseGetClubCardDtoBL> clubCards)
                where Result : ICollection<ResponseGetClubCardDtoUI>
        {
            return clubCards.Select(x => Map<ResponseGetClubCardDtoUI>(x)).ToList();
        }
    }
}
