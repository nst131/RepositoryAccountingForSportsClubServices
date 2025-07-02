using System;

namespace ServiceAccountingBL.Models.VisitBLL.Dto
{
    public class ResponseVisitDtoBL
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        public string ClientName { get; set; }
    }
}