using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.VisitUI.Dto
{
    public class AcceptUpdateVisitDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "arrival", Order = 1, Required = Required.AllowNull)]
        public DateTime? Arrival { get; set; }

        [JsonProperty(PropertyName = "clientId", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "serviceId", Order = 3, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ServiceId { get; set; }
    }
}