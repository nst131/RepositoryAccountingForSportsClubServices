using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Mapper
{
    public static class ResponseClientCardMapperBL
    {
        public static ResponseClientCardDtoBL Map<Result>(ClientCard dto)
            where Result : ResponseClientCardDtoBL
        {
            return new()
            {
                Id = dto.Id,
                DateActivation = dto.DateActivation,
                DateExpiration = dto.DateExpiration
            };
        }
    }
}
