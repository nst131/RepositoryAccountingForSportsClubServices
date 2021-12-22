using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public class CreateDealMapperBL : IMapper<AcceptCreateDealDtoBL, Deal>
    {
        public Deal Map(AcceptCreateDealDtoBL dto)
        {
            return new()
            {
                PurchaseDate = dto.PurchaseDate,
                SubscriptionId = dto.SubscriptionId,//? (can be null)
                ClubCardId = dto.ClubCardId, //? (can be null)
                ClientId = dto.ClientId,
                ResponsibleId = dto.ResponsibleId
            };
        }
    }
}
