using System;

namespace ServiceAccountingBL.Models.ClientCardBL.Dto
{
    public class ResponseGetClientCardDtoBL
    {
        public int Id { get; set; }
        public DateTime DateActivation { get; set; }
        public DateTime DateExpiration { get; set; }
        public string ServiceName { get; set; }
        public string ClubCardName { get; set; }
    }
}
