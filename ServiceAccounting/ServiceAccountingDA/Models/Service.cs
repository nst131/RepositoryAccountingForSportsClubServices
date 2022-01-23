using System.Collections.Generic;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInMinutes { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public ICollection<ClubCard> ClubCards { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<ClientCard> ClientCards { get; set; }
    }
}