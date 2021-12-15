﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClientUI.Dto
{
    [DataContract]
    public class UpdateClientDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 1, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(SerName), Order = 2, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Telephone), Order = 3, EmitDefaultValue = false)]
        [RegularExpression(@"[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Не правильный номер телефона")]
        public string Telephone { get; set; }

        [DataMember(IsRequired = true, Name = nameof(TypeSexId), Order = 4, EmitDefaultValue = true)]
        [Range(1, 2, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int TypeSexId { get; set; }
    }
}
