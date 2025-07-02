using System;

namespace ServiceAccountingBL.Models.TrainingBLL.Dto
{
    public class ResponseGetTrainingDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTraining { get; set; }
        public DateTime FinishTraining { get; set; }
        public string TrainerName { get; set; }
        public string ServiceName { get; set; }
    }
}