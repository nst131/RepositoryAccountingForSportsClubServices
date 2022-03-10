using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class ResponseVisitInfDtoUI
    {
        [JsonProperty(PropertyName = "arrival", Order = 0, Required = Required.Always)]
        public string Arrival { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 2, Required = Required.Always)]
        public string ServiceName { get; set; }
    }
}
