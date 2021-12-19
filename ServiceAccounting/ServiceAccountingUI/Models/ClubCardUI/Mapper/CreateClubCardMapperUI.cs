using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingUI.Models.ClubCardUI.Dto;

namespace ServiceAccountingUI.Models.ClubCardUI.Mapper
{
    public static class CreateClubCardMapperUI
    {
        public static CreateClubCardDtoBL Map<Result>(AcceptCreateClubCardDtoUI clubCard)
            where Result : CreateClubCardDtoBL
        {
            return new ()
            {
                Name = clubCard.Name,
                Price = clubCard.Price,
                DurationInDays = clubCard.DurationInDays,
                ServiceId = clubCard.ServiceId
            };
        }

        public static ResponseClubCardDtoUI Map<Result>(ClubCardDtoBL clubCard)
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
