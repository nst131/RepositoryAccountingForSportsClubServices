using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServiceAccountingUI.Models.ResponsibleUI.Dto
{
    public class AcceptUpdateResponsibleDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 2, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 3, Required = Required.Always)]
        [RegularExpression(@"[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Не правильный номер телефона")]
        public string Telephone { get; set; }
    }
}
