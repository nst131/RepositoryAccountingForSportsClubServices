using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class ResponseTrainingInfDtoUI
    {
        [JsonProperty(PropertyName = "startTraining", Order = 0, Required = Required.Always)]
        public string StartTraining { get; set; }

        [JsonProperty(PropertyName = "finishTraining", Order = 1, Required = Required.Always)]
        public string FinishTraining { get; set; }

        [JsonProperty(PropertyName = "trainerName", Order = 2, Required = Required.Always)]
        public string TrainerName { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 3, Required = Required.Always)]
        public string ServiceName { get; set; }
    }
}
