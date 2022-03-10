namespace RabbitMQLibrary
{
    public interface IRabbitMqHostConfigurator
    {
        IEventBusConfigurator UseRabbitMq(RabbitMqOptions options);
    }
}