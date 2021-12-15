using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClubCardBLL.Mapper
{
    public static class CreateClubCardMapperBL
    {
        public static ClubCard Map<Result>(CreateClubCardDtoBL createClubCardDtoBL)
            where Result : ClubCard
        {
            return new ClubCard()
            {
                Name = createClubCardDtoBL.Name,
                Price = createClubCardDtoBL.Price,
                DurationInDays = createClubCardDtoBL.DurationInDays,
                ServiceId = createClubCardDtoBL.ServiceId
            };
        }
    }
}
