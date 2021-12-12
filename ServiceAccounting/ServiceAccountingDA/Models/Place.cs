using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountFreePlace { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
