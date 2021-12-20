using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClientCardUI.Dto
{
    public class AcceptCreateClientCardDtoUI
    {
        // В Postman отправляет норм defaultValue, Swagger показывает не верно. 
        [JsonProperty(PropertyName = "dateActivation", Order = 0, Required = Required.Always)]
        public DateTime DateActivation { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "clubCardId", Order = 1, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClubCardId { get; set; }

        [JsonProperty(PropertyName = "clientId", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClientId { get; set; }
    }
}