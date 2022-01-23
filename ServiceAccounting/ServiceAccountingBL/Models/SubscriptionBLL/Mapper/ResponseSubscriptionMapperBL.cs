using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Mapper
{
    public static class ResponseSubscriptionMapperBL
    {
        public static ResponseSubscriptionDtoBL Map<Result>(ServiceAccountingDA.Models.Subscription dto)
            where Result : ResponseSubscriptionDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts
            };
        }
    }
}