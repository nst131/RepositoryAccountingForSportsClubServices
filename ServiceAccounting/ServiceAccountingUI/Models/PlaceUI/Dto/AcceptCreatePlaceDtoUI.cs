using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.PlaceUI.Dto
{
    public class AcceptCreatePlaceDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "amountFreePlace", Order = 1, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int AmountFreePlace { get; set; }
    }
}
