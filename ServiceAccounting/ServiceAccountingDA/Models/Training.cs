using System;
using System.Collections.Generic;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingDA.Models
{
    public class Training : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTraining { get; set; }
        public DateTime FinishTraining { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public int ServicesId { get; set; }
        public Service Service { get; set; }

        public ICollection<TrainingToClient> Clients { get; set; }
    }
}
