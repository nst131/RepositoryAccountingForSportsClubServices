namespace ServiceAccountingBL.Models.ClubCardBLL.Dto
{
    public class AcceptUpdateClubCardDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public int ServiceId { get; set; }
    }
}
