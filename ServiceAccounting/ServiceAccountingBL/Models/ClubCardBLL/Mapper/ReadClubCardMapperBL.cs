using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class ReadClubCardMapperBL
    {
        public static ResponseGetClubCardDtoBL Map<Result>(ClubCard clubCard)
            where Result : ResponseGetClubCardDtoBL
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

        public static ICollection<ResponseGetClubCardDtoBL> Map<Result>(ICollection<ClubCard> allClubCards)
             where Result : ICollection<ResponseGetClubCardDtoBL>
        {
            return allClubCards.Select(clubCard => Map<ResponseGetClubCardDtoBL>(clubCard)).ToList();
        }
    }
}
