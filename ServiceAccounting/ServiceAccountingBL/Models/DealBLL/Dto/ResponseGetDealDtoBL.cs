#nullable enable
using System;

namespace ServiceAccountingBL.Models.DealBLL.Dto
{
    public class ResponseGetDealDtoBL
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? SubscriptionName { get; set; }
        public int? SubscriptionAmountWorkouts { get; set; }
        public string? ClubCardName { get; set; }

        public string? ClientName { get; set; }
        public string? ResponsibleName { get; set; }
    }
}