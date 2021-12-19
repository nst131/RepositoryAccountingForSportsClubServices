using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class CreateClubCardMapperBL : IMapper<CreateClubCardDtoBL, ClubCard>
    {
        public ClubCard Map(CreateClubCardDtoBL createClubCardDtoBL)
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
