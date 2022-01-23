using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Mapper
{
    public static class ReadSubscriptionMapperBL
    {
        public static ResponseGetSubscriptionDtoBL Map<Result>(ServiceAccountingDA.Models.Subscription dto)
            where Result : ResponseGetSubscriptionDtoBL
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                AmountWorkouts = dto.AmountWorkouts,
                Price = dto.Price,
                ServiceName = dto.Service.Name
            };
        }

        public static ICollection<ResponseGetSubscriptionDtoBL> Map<Result>(ICollection<ServiceAccountingDA.Models.Subscription> alldtos)
            where Result : ICollection<ResponseGetSubscriptionDtoBL>
        {
            return alldtos.Select(client => Map<ResponseGetSubscriptionDtoBL>(client)).ToList();
        }
    }
}
