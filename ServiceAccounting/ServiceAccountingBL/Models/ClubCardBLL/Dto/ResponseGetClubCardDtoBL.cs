namespace ServiceAccountingBL.Models.ClubCardBLL.Dto
{
    public class ResponseGetClubCardDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public string Service { get; set; }
    }
}
