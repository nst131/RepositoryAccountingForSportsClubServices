using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class UpdateClubCardMapperBL : IMapper<AcceptUpdateClubCardDtoBL, ClubCard>
    {
        public ClubCard Map(AcceptUpdateClubCardDtoBL updateClubCardDtoBL)
        {
            return new ()
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
