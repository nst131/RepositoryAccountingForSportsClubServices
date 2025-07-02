using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class ResponseSubscriptionInfDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Default)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "amountWorkouts", Order = 1, Required = Required.Default)]
        public string AmountWorkouts { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 2, Required = Required.Default)]
        public string ServiceName { get; set; }
    }
}
