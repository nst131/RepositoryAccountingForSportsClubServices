﻿using System.Runtime.Serialization;

namespace ServiceAccountingUI.ResponsibleUI.Dto
{
    [DataContract]
    public class ResponsibleDtoUI
    {
        [DataMember(IsRequired = true, Name = nameof(Id), Order = 0, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true, Name = nameof(Name), Order = 1, EmitDefaultValue = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = nameof(SerName), Order = 2, EmitDefaultValue = true)]
        public string SerName { get; set; }
    }
}
