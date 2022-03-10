using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using ServiceAccountingUI.CustomAttributes;

namespace ServiceAccountingUI.Models.DealUI.Dto
{
    [SingleClientCardAndUniqueSubscription]
    public class AcceptCreateDealDtoUI
    {
        [JsonProperty(PropertyName = "purchaseDate", Order = 0, Required = Required.AllowNull)]
        public DateTime? PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "subscriptionId", Order = 1, Required = Required.AllowNull)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int? SubscriptionId { get; set; }

        [JsonProperty(PropertyName = "clubCardId", Order = 2, Required = Required.AllowNull)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int? ClubCardId { get; set; }

        [JsonProperty(PropertyName = "clientId", Order = 3, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "responsibleId", Order = 4, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ResponsibleId { get; set; }
    }
}