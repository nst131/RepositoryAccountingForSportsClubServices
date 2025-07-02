using ServiceAccountingBL.BaseModels;
using System;
using System.Collections.Generic;

namespace ServiceAccountingBL.Models.TrainingBLL.Dto
{
    public class ResponseTrainingDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTraining { get; set; }
        public ICollection<ClientsHasExpiredDto> ClientsHasExpired { get; set; }
    }
}