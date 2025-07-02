using System;

namespace ServiceAccountingBL.Models.DealBLL.Dto
{
    public class ResponseDealDtoBL
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ClientName { get; set; }
    }
}