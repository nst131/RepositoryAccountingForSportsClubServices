using System.Collections.Generic;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class Place : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountFreePlace { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
