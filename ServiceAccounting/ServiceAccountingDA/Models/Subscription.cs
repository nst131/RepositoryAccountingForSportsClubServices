using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountWorkouts { get; set; }
        public float Price { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        public ICollection<Client> Clients { get; set; }
        public ICollection<Deal> Deals { get; set; } 
    }
}
