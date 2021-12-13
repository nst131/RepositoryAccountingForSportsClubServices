using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClientUI.Dto
{
    [DataContract]
    public class UpdateClientDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 1, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(SerName), Order = 2, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Telephone), Order = 3, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Telephone { get; set; }

        [DataMember(IsRequired = true, Name = nameof(TypeSexId), Order = 4, EmitDefaultValue = true)]
        public int TypeSexId { get; set; }
    }
}
