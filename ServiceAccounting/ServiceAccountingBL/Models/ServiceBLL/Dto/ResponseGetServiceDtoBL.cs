namespace ServiceAccountingBL.Models.ServiceBLL.Dto
{
    public class ResponseGetServiceDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DurationInMinutes { get; set; }
        public string PlaceName { get; set; }
    }
}