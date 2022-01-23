using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class CreateClubCardMapperBL : IMapper<AcceptCreateClubCardDtoBL, ClubCard>
    {
        public ClubCard Map(AcceptCreateClubCardDtoBL createClubCardDtoBL)
        {
            return new ()
            {
                Name = createClubCardDtoBL.Name,
                Price = createClubCardDtoBL.Price,
                DurationInDays = createClubCardDtoBL.DurationInDays,
                ServiceId = createClubCardDtoBL.ServiceId
            };
        }
    }
}
