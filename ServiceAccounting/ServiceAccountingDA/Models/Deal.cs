using System;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class Deal : IEntity
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }

        public int? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public int? ClubCardId { get; set; }
        public ClubCard ClubCard { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ResponsibleId { get; set; }
        public Responsible Responsible { get; set; }
    }
}
