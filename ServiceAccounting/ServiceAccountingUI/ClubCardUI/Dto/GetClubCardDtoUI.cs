using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClubCardUI.Dto
{
    [DataContract]
    public class GetClubCardDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 1, EmitDefaultValue = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Price), Order = 2, EmitDefaultValue = true)]
        public string Price { get; set; }

        [DataMember(IsRequired = true, Name = nameof(DurationInDays), Order = 3, EmitDefaultValue = true)]
        public string DurationInDays { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Service), Order = 4, EmitDefaultValue = true)]
        public string Service { get; set; }
    }
}
