using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public sealed class TypeOfSex : Enumeration
    {
        public TypeOfSex(int id, string name) : base(id, name) { }

        public static readonly TypeOfSex Man = new(1, nameof(Man));
        public static readonly TypeOfSex Woman = new(2, nameof(Woman));
        public static readonly TypeOfSex NoGender = new(3, nameof(NoGender));

        public ICollection<Client> Clients { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }
}
