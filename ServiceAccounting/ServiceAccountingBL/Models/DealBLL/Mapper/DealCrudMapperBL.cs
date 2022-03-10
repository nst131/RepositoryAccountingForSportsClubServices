using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public static class DealCrudMapperBL
    {
        public static AcceptCreateDealDtoBL Map<Response>(AcceptUpdateDealDtoBL dto)
            where Response: AcceptCreateDealDtoBL
        {
            return new()
            {
                ClientId = dto.ClientId,
                SubscriptionId = dto.SubscriptionId,
                ClubCardId = dto.ClubCardId,
                PurchaseDate = dto.PurchaseDate,
                ResponsibleId = dto.ResponsibleId
            };
        }

        public static SubscriptionToClient Map<Response>(AcceptCreateDealDtoBL dto)
            where Response : SubscriptionToClient
        {
            return new()
            {
                ClientId = dto.ClientId,
                SubscriptionId = dto.SubscriptionId ?? default
            };
        }

        public static AcceptCreateClientCardDtoBL Map<Response>(in AcceptCreateDealDtoBL dto)
            where Response : AcceptCreateClientCardDtoBL
        {
            return new()
            {
                ClientId = dto.ClientId,
                ClubCardId = dto.ClubCardId ?? default,
                DateActivation = dto.PurchaseDate
            };
        }
    }
}
