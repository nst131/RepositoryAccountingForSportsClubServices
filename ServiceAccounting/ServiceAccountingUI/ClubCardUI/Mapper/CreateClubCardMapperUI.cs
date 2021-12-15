using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingUI.ClubCardUI.Dto;

namespace ServiceAccountingUI.ClubCardUI.Mapper
{
    public static class CreateClubCardMapperUI
    {
        public static CreateClubCardDtoBL Map<Result>(CreateClubCardDtoUI clubCard)
            where Result : CreateClubCardDtoBL
        {
            return new CreateClubCardDtoBL()
            {
                Name = clubCard.Name,
                Price = clubCard.Price,
                DurationInDays = clubCard.DurationInDays,
                ServiceId = clubCard.ServiceId
            };
        }

        public static ClubCardDtoUI Map<Result>(ClubCardDtoBL clubCard)
            where Result : ClubCardDtoUI
        {
            return new ClubCardDtoUI()
            {
                Id = clubCard.Id,
                Name = clubCard.Name
            };
        }
    }
}
