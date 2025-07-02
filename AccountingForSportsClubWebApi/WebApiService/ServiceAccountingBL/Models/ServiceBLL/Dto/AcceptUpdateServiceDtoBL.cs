namespace ServiceAccountingBL.Models.ServiceBLL.Dto
{
    public class AcceptUpdateServiceDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInMinutes { get; set; }
        public int PlaceId { get; set; }
    }
}