using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingUI.Models.DealUI.Dto;

namespace ServiceAccountingUI.Models.DealUI.Mapper
{
    public class ReadDealMapperUI
    {
        public static ResponseGetDealDtoUI Map<Result>(ResponseGetDealDtoBL dto)
            where Result : ResponseGetDealDtoUI
        {
            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dto.ClientName, //? required
                ResponsibleName = dto.ResponsibleName, //? required
                ClubCardName = dto.ClubCardName ?? "Nothing", //? can be null
                SubscriptionName = dto.SubscriptionName ?? "Nothing", //? can be null
                SubscriptionAmountWorkouts = dto.SubscriptionAmountWorkouts ?? 0 //? can be null
            };
        }

        public static ICollection<ResponseGetDealDtoUI> Map<Result>(ICollection<ResponseGetDealDtoBL> dtos)
            where Result : ICollection<ResponseGetDealDtoUI>
        {
            return dtos.Select(dto => Map<ResponseGetDealDtoUI>(dto)).ToList();
        }
    }
}
