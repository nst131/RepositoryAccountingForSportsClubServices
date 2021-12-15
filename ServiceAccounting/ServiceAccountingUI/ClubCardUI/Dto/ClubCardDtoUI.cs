using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClubCardUI.Dto
{
    [DataContract]
    public class ClubCardDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }
    }
}
