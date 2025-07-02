using ServiceAccountingDA.Interfaces;
using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Client : BaseEntity, ITelephone, IEntity, IEmail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ClientCard ClientCard { get; set; }

        public int TypeSexId { get; set; }
        public TypeOfSex TypeSex { get; set; }

        public ICollection<TrainingToClient> Trainings { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<SubscriptionToClient> Subscriptions { get; set; }
        public ICollection<Deal> Deals { get; set; }
    }
}
