using ServiceAccountingDA.Interfaces;
using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Responsible : ITelephone, IEntity, IEmail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ICollection<Deal> Deals { get; set; }
    }
}
