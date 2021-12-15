using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClubCardUI.Dto
{
    [DataContract]
    public class CreateClubCardDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Name), Order = 0, EmitDefaultValue = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Price), Order = 1, EmitDefaultValue = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public float Price { get; set; }

        [DataMember(IsRequired = true, Name = nameof(DurationInDays), Order = 2, EmitDefaultValue = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int DurationInDays { get; set; }

        [DataMember(IsRequired = true, Name = nameof(ServiceId), Order = 3, EmitDefaultValue = true)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int ServiceId { get; set; }
    }
}
