using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.CustomAttributes;

namespace ServiceAccountingUI.Models.ResponsibleUI.Dto
{
    public class AcceptCreateResponsibleDtoUI
    {
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Email", Order = 1, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [RegularExpression(@"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z", ErrorMessage = "Некоректно введен Email")]
        [UniqueEmail(Roles.Responsible)]
        public string Email { get; set; }
    }
}
