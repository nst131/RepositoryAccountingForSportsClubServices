using System;

namespace ServiceAccountingDA.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
