using System;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class Visit : IEntity
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
