using System;

namespace ServiceAccountingBL.Models.VisitBLL.Dto
{
    public class AcceptCreateVisitDtoBL
    {
        public DateTime Arrival { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
    }
}
