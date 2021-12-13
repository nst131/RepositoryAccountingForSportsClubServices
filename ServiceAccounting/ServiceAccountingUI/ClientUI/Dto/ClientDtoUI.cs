using System.Runtime.Serialization;

namespace ServiceAccountingUI.ClientUI.Dto
{
    [DataContract]
    public class ClientDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 0, EmitDefaultValue = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(SerName), Order = 0, EmitDefaultValue = true)]
        public string SerName { get; set; }
    }
}
