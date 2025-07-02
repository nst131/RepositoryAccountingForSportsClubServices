using System;
using System.Collections.Generic;

namespace ServiceAccountingBL.Models.TrainingBLL.Dto
{
    public class AcceptCreateTrainingDtoBL
    {
        public string Name { get; set; }
        public DateTime StartTraining { get; set; }

        public int TrainerId { get; set; }
        public int ServicesId { get; set; }

        public ICollection<int> ClientsId { get; set; }
    }
}
