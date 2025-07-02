namespace RabbitMQLibrary
{
    public interface IEventBusConfigurator
    {
        IEventBusConfigurator Subscribe<T, TH>(SubscriptionType type = SubscriptionType.Queue)
            where T : class
            where TH : IIntegrationHandler<T>;

        IEventBusConfigurator Subscribe<T, TH>(SubscriptionOptions options)
            where T : class
            where TH : IIntegrationHandler<T>;
    }
}