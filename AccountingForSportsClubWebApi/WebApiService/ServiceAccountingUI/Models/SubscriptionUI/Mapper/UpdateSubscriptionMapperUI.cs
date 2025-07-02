using System.Collections.Generic;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;

namespace ServiceAccountingUI.Models.SubscriptionUI.Mapper
{
    public class UpdateSubscriptionMapperUI
    {
        public static AcceptUpdateSubscriptionDtoBL Map<Result>(AcceptUpdateSubscriptionDtoUI dto)
            where Result : AcceptUpdateSubscriptionDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceId = dto.ServiceId,
                ClientsId = dto.ClientsId ?? new List<int>()
            };
        }
    }
}
