using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.DealUI.Dto
{
    public class ResponseDealDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "purchaseDate", Order = 1, Required = Required.Always)]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "clientName", Order = 2, Required = Required.Always)]
        public string ClientName { get; set; }
    }
}