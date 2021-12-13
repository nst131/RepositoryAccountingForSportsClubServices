using ServiceAccountingDA.Interfaces;
using System.Collections.Generic;

namespace ServiceAccountingDA.Models
{
    public class Responsible : ITelephone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Telephone { get; set; }

        public ICollection<Deal> Deals { get; set; }
    }
}
