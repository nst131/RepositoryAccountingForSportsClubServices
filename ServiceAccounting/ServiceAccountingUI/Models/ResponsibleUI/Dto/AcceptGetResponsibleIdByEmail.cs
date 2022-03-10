﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.Models.ResponsibleUI.Dto
{
    public class AcceptGetResponsibleIdByEmail
    {
        [JsonProperty(PropertyName = "Email", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [RegularExpression(@"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z", ErrorMessage = "Некоректно введен Email")]
        public string Email { get; set; }
    }
}
