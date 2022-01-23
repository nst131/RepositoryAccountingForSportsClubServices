using System;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingUI.Models.DealUI.Dto;

namespace ServiceAccountingUI.Models.DealUI.Mapper
{
    public class UpdateDealMapperUI
    {
        public static AcceptUpdateDealDtoBL Map<Result>(AcceptUpdateDealDtoUI dto)
            where Result : AcceptUpdateDealDtoBL
        {
            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate ?? DateTime.Now.ToLocalTime(),
                ClientId = dto.ClientId,
                ResponsibleId = dto.ResponsibleId,
                ClubCardId = dto.ClubCardId, //? can be null
                SubscriptionId = dto.SubscriptionId //? can be null
            };
        }

        public static ResponseDealDtoUI Map<Result>(ResponseDealDtoBL dto)
            where Result : ResponseDealDtoUI
        {
            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dto.ClientName
            };
        }
    }
}
