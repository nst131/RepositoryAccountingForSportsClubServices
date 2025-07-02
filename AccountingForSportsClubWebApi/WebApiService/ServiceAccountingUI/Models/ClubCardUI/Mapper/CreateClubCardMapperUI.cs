using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingUI.Models.ClubCardUI.Dto;

namespace ServiceAccountingUI.Models.ClubCardUI.Mapper
{
    public static class CreateClubCardMapperUI
    {
        public static AcceptCreateClubCardDtoBL Map<Result>(AcceptCreateClubCardDtoUI clubCard)
            where Result : AcceptCreateClubCardDtoBL
        {
            return new ()
            {
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
