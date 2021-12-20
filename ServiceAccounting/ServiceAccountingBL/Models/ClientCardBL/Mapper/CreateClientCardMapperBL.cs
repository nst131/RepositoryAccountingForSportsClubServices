using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Mapper
{
    public static class CreateClientCardMapperBL
    {
        public static ClientCard Map<Result>(AcceptCreateClientCardDtoBL dto)
            where Result: ClientCard
        {
            return new()
            {
                DateActivation = dto.DateActivation,
                ClubCardId = dto.ClubCardId,
                ClientId = dto.ClientId
            };
        }
    }
}
