using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;
using System.Collections.Generic;

namespace ServiceAccountingBL.ClubCardBLL.Mapper
{
    public class GetClubCardMapperBL
    {
        public static GetClubCardDtoBL Map<Result>(ClubCard clubCard)
            where Result : GetClubCardDtoBL
        {
            return new GetClubCardDtoBL()
            {
                Id = clubCard.Id,
                Name = clubCard.Name,
                Price = clubCard.Price,
                DurationInDays = clubCard.DurationInDays,
                Service = clubCard.Service.Name
            };
        }

        public static ICollection<GetClubCardDtoBL> Map<Result>(ICollection<ClubCard> allClubCards)
             where Result : ICollection<GetClubCardDtoBL>
        {
            var allClubCardsDto = new List<GetClubCardDtoBL>();

            foreach (var clubCard in allClubCards)
            {
                allClubCardsDto.Add(Map<GetClubCardDtoBL>(clubCard));
            }

            return allClubCardsDto;
        }
    }
}
