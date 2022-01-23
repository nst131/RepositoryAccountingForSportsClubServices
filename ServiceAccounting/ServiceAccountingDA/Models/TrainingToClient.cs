namespace ServiceAccountingDA.Models
{
    public class TrainingToClient
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
