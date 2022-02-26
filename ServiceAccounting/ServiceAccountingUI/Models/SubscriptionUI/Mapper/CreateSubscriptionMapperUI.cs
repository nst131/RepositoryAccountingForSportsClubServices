using System.Collections.Generic;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;

namespace ServiceAccountingUI.Models.SubscriptionUI.Mapper
{
    public static class CreateSubscriptionMapperUI
    {
        public static AcceptCreateSubscriptionDtoBL Map<Result>(AcceptCreateSubscriptionDtoUI dto)
            where Result : AcceptCreateSubscriptionDtoBL
        {
            return new()
            {
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceId = dto.ServiceId,
                ClientsId = dto.ClientsId ?? new List<int>()
            };
        }
    }
}
