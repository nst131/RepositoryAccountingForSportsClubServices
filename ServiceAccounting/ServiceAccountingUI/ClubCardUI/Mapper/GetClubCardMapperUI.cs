using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingUI.ClubCardUI.Dto;
using System.Collections.Generic;

namespace ServiceAccountingUI.ClubCardUI.Mapper
{
    public static class GetClubCardMapperUI
    {
        public static GetClubCardDtoUI Map<Result>(GetClubCardDtoBL clubCard)
        where Result : GetClubCardDtoUI
        {
            return new GetClubCardDtoUI()
            {
                Id = clubCard.Id,
                Name = clubCard.Name,
                Price = clubCard.Price + " rub",
                DurationInDays = clubCard.DurationInDays.ToString() + " days",
                Service = clubCard.Service
            };
        }

        public static ICollection<GetClubCardDtoUI> Map<Result>(ICollection<GetClubCardDtoBL> clubCards)
                where Result : ICollection<GetClubCardDtoUI>
        {
            var clubCardsDtoUI = new List<GetClubCardDtoUI>();

            foreach (var clubCard in clubCards)
            {
                clubCardsDtoUI.Add(Map<GetClubCardDtoUI>(clubCard));
            }

            return clubCardsDtoUI;
        }
    }
}
