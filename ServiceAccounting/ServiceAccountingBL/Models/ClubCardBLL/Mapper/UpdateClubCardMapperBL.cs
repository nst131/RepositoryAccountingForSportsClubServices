using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class UpdateClubCardMapperBL : IMapper<UpdateClubCardDtoBL, ClubCard>
    {
        public ClubCard Map(UpdateClubCardDtoBL updateClubCardDtoBL)
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
