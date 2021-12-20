using System;

namespace ServiceAccountingBL.Models.ClientCardBL.Dto
{
    public class AcceptUpdateClientCardDtoBL
    {
        public int Id { get; set; }
        public DateTime DateActivation { get; set; }
        public int ClubCardId { get; set; }
        public int ClientId { get; set; }
    }
}
