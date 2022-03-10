using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ServiceAccountingUI.CustomAttributes;

namespace ServiceAccountingUI.Models.ClientCardUI.Dto
{
    public class AcceptCreateClientCardDtoUI
    {
        [JsonProperty(PropertyName = "dateActivation", Order = 0, Required = Required.AllowNull)]
        public DateTime? DateActivation { get; set; }

        [JsonProperty(PropertyName = "clubCardId", Order = 1, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClubCardId { get; set; }

        [JsonProperty(PropertyName = "clientId", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [CheckClientCardOnExistance]
        public int ClientId { get; set; }
    }
}