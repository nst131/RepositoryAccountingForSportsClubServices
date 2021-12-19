using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.CustomAttributes;

namespace ServiceAccountingUI.Models.ClientUI.Dto
{
    public class AcceptCreateClientDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 1, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 2, Required = Required.Always)]
        [RegularExpression(@"[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Не правильный номер телефона")]
        [UniqueTelephone(Role.Client)]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "typeSexId", Order = 3, Required = Required.Always)]
        [Range(1, 2, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int TypeSexId { get; set; }
    }
}
