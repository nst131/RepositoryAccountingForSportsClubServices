using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;

namespace ServiceAccountingUI.Models.SubscriptionUI.Mapper
{
    public class ReadSubscriptionMapperUI
    {
        public static ResponseGetSubscriptionDtoUI Map<Result>(ResponseGetSubscriptionDtoBL dto)
            where Result : ResponseGetSubscriptionDtoUI
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts.ToString(),
                Price = dto.Price.ToString(),
                ServiceName = dto.ServiceName
            };
        }

        public static ICollection<ResponseGetSubscriptionDtoUI> Map<Result>(ICollection<ResponseGetSubscriptionDtoBL> dtos)
            where Result : ICollection<ResponseGetSubscriptionDtoUI>
        {
            return dtos.Select(subscription => Map<ResponseGetSubscriptionDtoUI>(subscription)).ToList();
        }
    }
}
