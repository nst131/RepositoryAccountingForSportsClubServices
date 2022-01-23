using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Mapper
{
    public static class UpdateClientCardMapperBL
    {
        public static ClientCard Map<Result>(AcceptUpdateClientCardDtoBL dto)
            where Result : ClientCard
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                ClubCardId = dto.ClubCardId,
                ClientId = dto.ClientId,
            };
        }
    }
}
