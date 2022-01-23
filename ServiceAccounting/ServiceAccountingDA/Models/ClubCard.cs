using System.Collections.Generic;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class ClubCard : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public ICollection<ClientCard> ClientCards { get; set; }
        public ICollection<Deal> Deals { get; set; }
    }
}
