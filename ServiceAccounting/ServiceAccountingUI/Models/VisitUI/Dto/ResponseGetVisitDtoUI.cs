using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.VisitUI.Dto
{
    public class ResponseGetVisitDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "arrival", Order = 1, Required = Required.Always)]
        public DateTime Arrival { get; set; }

        [JsonProperty(PropertyName = "clientName", Order = 2, Required = Required.Always)]
        public string ClientName { get; set; }

        [JsonProperty(PropertyName = "serviceName", Order = 3, Required = Required.Always)]
        public string ServiceName { get; set; }
    }
}