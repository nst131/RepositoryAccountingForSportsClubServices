using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.VisitUI.Dto
{
    public class ResponseVisitDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "arrival", Order = 1, Required = Required.Always)]
        public DateTime Arrival { get; set; }

        [JsonProperty(PropertyName = "clientName", Order = 2, Required = Required.Always)]
        public string ClientName { get; set; }
    }
}