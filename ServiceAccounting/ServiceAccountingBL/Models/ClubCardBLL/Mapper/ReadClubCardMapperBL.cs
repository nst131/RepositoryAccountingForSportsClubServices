using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class ReadClubCardMapperBL
    {
        public static GetClubCardDtoBL Map<Result>(ClubCard clubCard)
            where Result : GetClubCardDtoBL
        {
            return new ()
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
            return allClubCards.Select(clubCard => Map<GetClubCardDtoBL>(clubCard)).ToList();
        }
    }
}
