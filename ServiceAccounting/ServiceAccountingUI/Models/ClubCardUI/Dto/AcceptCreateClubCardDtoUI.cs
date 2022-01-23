using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ClubCardUI.Dto
{
    public class AcceptCreateClubCardDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price", Order = 1, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public float Price { get; set; }

        [JsonProperty(PropertyName = "durationInDays", Order = 2, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int DurationInDays { get; set; }

        [JsonProperty(PropertyName = "serviceId", Order = 3, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ServiceId { get; set; }
    }
}
