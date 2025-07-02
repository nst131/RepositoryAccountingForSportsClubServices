using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingUI.Models.ClubCardUI.Dto;

namespace ServiceAccountingUI.Models.ClubCardUI.Mapper
{
    public static class UpdateClubCardMapperUI
    {
        public static AcceptUpdateClubCardDtoBL Map<Result>(AcceptUpdateClubCardDtoUI clubCard)
            where Result : AcceptUpdateClubCardDtoBL
        {
            return new ()
            {
                Id = clubCard.Id,
                Name = clubCard.Name,
                Price = clubCard.Price,
                DurationInDays = clubCard.DurationInDays,
                ServiceId = clubCard.ServiceId
            };
        }

        public static ResponseClubCardDtoUI Map<Result>(ResponseClubCardDtoBL clubCard)
            where Result : ResponseClubCardDtoUI
        {
            return new ()
            {
                Id = clubCard.Id,
                Name = clubCard.Name
            };
        }
    }
}
