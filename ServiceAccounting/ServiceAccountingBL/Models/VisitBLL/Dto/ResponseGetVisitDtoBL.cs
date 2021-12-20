using System;

namespace ServiceAccountingBL.Models.VisitBLL.Dto
{
    public class ResponseGetVisitDtoBL
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
    }
}