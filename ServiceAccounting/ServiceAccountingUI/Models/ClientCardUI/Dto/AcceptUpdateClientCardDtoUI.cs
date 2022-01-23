using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClientCardUI.Dto
{
    public class AcceptUpdateClientCardDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "dateActivation", Order = 1, Required = Required.AllowNull)]
        public DateTime? DateActivation { get; set; }


        [JsonProperty(PropertyName = "clubCardId", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClubCardId { get; set; }


        [JsonProperty(PropertyName = "clientId", Order = 3, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClientId { get; set; }
    }
}
