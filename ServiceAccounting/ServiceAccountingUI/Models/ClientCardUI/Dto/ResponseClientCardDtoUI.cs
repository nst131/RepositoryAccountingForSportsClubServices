using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClientCardUI.Dto
{
    public class ResponseClientCardDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "dateActivation", Order = 1, Required = Required.Always)]
        public DateTime DateActivation { get; set; }

        [JsonProperty(PropertyName = "dateExpiration", Order = 2, Required = Required.Always)]
        public DateTime DateExpiration { get; set; }
    }
}
