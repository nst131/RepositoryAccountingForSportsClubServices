using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceAccountingUI.ResponsibleUI.Dto
{
    [DataContract]
    public class CreateResponsibleDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Name), Order = 0, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(SerName), Order = 1, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Telephone), Order = 2, EmitDefaultValue = false)]
        [RegularExpression(@"[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Не правильный номер телефона")]
        public string Telephone { get; set; }
    }
}
