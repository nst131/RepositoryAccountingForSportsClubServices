namespace ServiceAccountingDA.Models
{
    public class SubscriptionToClient
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
