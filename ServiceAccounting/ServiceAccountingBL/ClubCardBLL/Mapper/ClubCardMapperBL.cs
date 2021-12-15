using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClubCardBLL.Mapper
{
    public static class ClubCardMapperBL
    {
        public static ClubCardDtoBL Map<Result>(ClubCard clubCard)
            where Result : ClubCardDtoBL
        {
            return new ClubCardDtoBL()
            {
                Id = clubCard.Id,
                Name = clubCard.Name
            };
        }
    }
}