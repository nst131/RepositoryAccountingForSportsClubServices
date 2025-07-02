using System;

namespace ServiceAccountingBL.Models.DealBLL.Dto
{
    public class AcceptCreateDealDtoBL
    {
        public DateTime PurchaseDate { get; set; }
        public int? SubscriptionId { get; set; }
        public int? ClubCardId { get; set; }
        public int ClientId { get; set; }
        public int ResponsibleId { get; set; }
    }
}
