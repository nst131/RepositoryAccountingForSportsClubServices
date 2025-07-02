#nullable enable
using System;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.DealUI.Dto
{
    public class ResponseGetDealDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "purchaseDate", Order = 1, Required = Required.Always)]
        public DateTime PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "subscriptionName", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string? SubscriptionName { get; set; }

        [JsonProperty(PropertyName = "subscriptionAmountWorkouts", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public int? SubscriptionAmountWorkouts { get; set; }

        [JsonProperty(PropertyName = "clubCardName", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public string? ClubCardName { get; set; }

        [JsonProperty(PropertyName = "clientName", Order = 5, Required = Required.Always)]
        public string? ClientName { get; set; }

        [JsonProperty(PropertyName = "responsibleName", Order = 6, Required = Required.Always)]
        public string? ResponsibleName { get; set; }
    }
}