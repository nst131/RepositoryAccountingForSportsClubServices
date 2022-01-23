using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.TrainingUI.Dto
{
    public class ResponseGetTrainingDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "startTraining", Order = 2, Required = Required.Always)]
        public DateTime StartTraining { get; set; }

        [JsonProperty(PropertyName = "finishTraining", Order = 3, Required = Required.Always)]
        public DateTime FinishTraining { get; set; }

        [JsonProperty(PropertyName = "trainerName", Order = 4, Required = Required.Always)]
        public string TrainerName { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 5, Required = Required.Always)]
        public string ServiceName { get; set; }
    }
}