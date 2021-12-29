using System;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class ClientCard : IEntity
    {
        public int Id { get; set; }
        public DateTime DateActivation { get; set; }
        public DateTime DateExpiration { get; set; }

        // Когда удалили ClubCard, знали какой Service предостовляет карта
        // ServiceId ClientCard = ServiceId ClubCard
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int ClubCardId { get; set; } 
        public ClubCard ClubCard { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
