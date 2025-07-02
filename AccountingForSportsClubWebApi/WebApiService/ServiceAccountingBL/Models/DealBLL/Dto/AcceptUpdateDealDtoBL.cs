using System;

namespace ServiceAccountingBL.Models.DealBLL.Dto
{
    public class AcceptUpdateDealDtoBL
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int? SubscriptionId { get; set; }
        public int? ClubCardId { get; set; }

        public int ClientId { get; set; }
        public int ResponsibleId { get; set; }
    }
}