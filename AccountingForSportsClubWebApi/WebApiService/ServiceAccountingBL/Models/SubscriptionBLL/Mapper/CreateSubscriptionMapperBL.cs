using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Mapper
{
    public static class CreateSubscriptionMapperBL
    {
        public static ServiceAccountingDA.Models.Subscription Map<Result>(AcceptCreateSubscriptionDtoBL dto)
            where Result : ServiceAccountingDA.Models.Subscription
        {
            return new()
            {
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceId = dto.ServiceId
            };
        }
    }
}