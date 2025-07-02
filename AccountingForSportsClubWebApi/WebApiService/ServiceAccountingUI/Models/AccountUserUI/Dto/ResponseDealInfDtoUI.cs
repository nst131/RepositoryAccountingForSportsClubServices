using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class ResponseDealInfDtoUI
    {
        [JsonProperty(PropertyName = "purchaseDate", Order = 0, Required = Required.Always)]
        public string PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "subscriptionName", Order = 1, Required = Required.Always)]
        public string SubscriptionName { get; set; }

        [JsonProperty(PropertyName = "clubCardName", Order = 2, Required = Required.Always)]
        public string ClubCardName { get; set; }
    }
}
