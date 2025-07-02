namespace ServiceAccountingBL.Models.SubscriptionBLL.Dto
{
    public class ResponseGetSubscriptionDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountWorkouts { get; set; }
        public float Price { get; set; }
        public string ServiceName { get; set; } // Load Service
    }
}