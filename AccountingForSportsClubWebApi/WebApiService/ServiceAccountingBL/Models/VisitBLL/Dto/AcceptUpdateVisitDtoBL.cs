using System;

namespace ServiceAccountingBL.Models.VisitBLL.Dto
{
    public class AcceptUpdateVisitDtoBL
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
    }
}