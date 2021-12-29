﻿using ServiceAccountingBL.Models.Subscription.Dto;

namespace ServiceAccountingBL.Models.Subscription.Mapper
{
    public static class UpdateSubscriptionMapperBL
    {
        public static ServiceAccountingDA.Models.Subscription Map<Result>(AcceptUpdateSubscriptionDtoBL dto)
            where Result : ServiceAccountingDA.Models.Subscription
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceId = dto.ServiceId
            };
        }
    }
}