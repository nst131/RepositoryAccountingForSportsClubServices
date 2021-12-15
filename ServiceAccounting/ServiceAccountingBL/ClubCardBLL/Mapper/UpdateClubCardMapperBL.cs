using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClubCardBLL.Mapper
{
    public class UpdateClubCardMapperBL
    {
        public static ClubCard Map<Result>(UpdateClubCardDtoBL updateClubCardDtoBL)
        where Result : ClubCard
        {
            return new ClubCard()
            {
                Id = updateClubCardDtoBL.Id,
                Name = updateClubCardDtoBL.Name,
                Price = updateClubCardDtoBL.Price,
                DurationInDays = updateClubCardDtoBL.DurationInDays,
                ServiceId = updateClubCardDtoBL.ServiceId
            };
        }
    }
}
