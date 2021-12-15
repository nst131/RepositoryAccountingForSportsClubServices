namespace ServiceAccountingBL.ClubCardBLL.Dto
{
    public class CreateClubCardDtoBL
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public int ServiceId { get; set; }
    }
}
