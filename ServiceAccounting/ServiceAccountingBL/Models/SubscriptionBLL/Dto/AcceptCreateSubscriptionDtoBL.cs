using System.Collections.Generic;

namespace ServiceAccountingBL.Models.SubscriptionBLL.Dto
{
    public class AcceptCreateSubscriptionDtoBL
    {
        public string Name { get; set; }
        public int AmountWorkouts { get; set; }
        public float Price { get; set; }
        public int ServiceId { get; set; }
        public ICollection<int> ClientsId { get; set; }
    }
}
