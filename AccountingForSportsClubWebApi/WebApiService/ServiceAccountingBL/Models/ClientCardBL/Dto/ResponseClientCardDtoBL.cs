using System;

namespace ServiceAccountingBL.Models.ClientCardBL.Dto
{
    public class ResponseClientCardDtoBL
    {
        public int Id { get; set; }
        public DateTime DateActivation { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
