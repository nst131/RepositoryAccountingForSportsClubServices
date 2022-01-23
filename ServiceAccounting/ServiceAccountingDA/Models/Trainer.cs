#nullable enable
using ServiceAccountingDA.Interfaces;
using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Trainer : ITelephone, IEntity, IEmail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        
        public int TypeSexId { get; set; }
        public TypeOfSex TypeSex { get; set; } 
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
