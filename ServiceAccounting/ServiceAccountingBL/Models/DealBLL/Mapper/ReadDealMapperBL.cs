using System.Collections.Generic;
using System.Linq;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.DealBLL.Mapper
{
    public static class ReadDealMapperBL
    {
        public static ResponseGetDealDtoBL Map<Result>(Deal dto)
            where Result : ResponseGetDealDtoBL
        {
            return new()
            {
                Id = dto.Id,
                PurchaseDate = dto.PurchaseDate,
                ClientName = dto.Client.Name, //? Load Client (must be requied)
                ClubCardName = dto.ClubCard?.Name, //? Load ClubCard (can be null)
                ResponsibleName = dto.Responsible.Name, //? Load Responsible (must be reqired)
                SubscriptionName = dto.Subscription?.Name, //? Load Subscription (can be null)
                SubscriptionAmountWorkouts = dto.Subscription?.AmountWorkouts //? Load Subscription (can be null)
            };
        }

        public static ICollection<ResponseGetDealDtoBL> Map<Result>(ICollection<Deal> allClients)
            where Result : ICollection<ResponseGetDealDtoBL>
        {
            return allClients.Select(client => Map<ResponseGetDealDtoBL>(client)).ToList();
        }
    }
}