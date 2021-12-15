using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingUI.ClubCardUI.Dto;

namespace ServiceAccountingUI.ClubCardUI.Mapper
{
    public static class UpdateClubCardMapperUI
    {
        public static UpdateClubCardDtoBL Map<Result>(UpdateClubCardDtoUI clubCard)
            where Result : UpdateClubCardDtoBL
        {
            return new UpdateClubCardDtoBL()
            {
                Id = clubCard.Id,
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
