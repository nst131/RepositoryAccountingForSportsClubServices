namespace RabbitMQLibrary
{
    public class SubscriptionOptions
    {
        public ushort? PrefetchCount { get; set; }

        public int? ConcurrencyLimits { get; set; }

        public SubscriptionType RegistrationType { get; set; } = SubscriptionType.Queue;
    }
}