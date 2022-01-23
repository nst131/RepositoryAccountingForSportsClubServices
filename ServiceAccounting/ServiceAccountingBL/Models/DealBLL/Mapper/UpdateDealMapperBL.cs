using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public class UpdateDealMapperBL : IMapper<AcceptUpdateDealDtoBL, Deal>
    {
        public Deal Map(AcceptUpdateDealDtoBL dto)
        {
            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                SubscriptionId = dto.SubscriptionId,//? (can be null)
                ClubCardId = dto.ClubCardId, //? (can be null)
                ClientId = dto.ClientId,
                ResponsibleId = dto.ResponsibleId
            };
        }
    }
}