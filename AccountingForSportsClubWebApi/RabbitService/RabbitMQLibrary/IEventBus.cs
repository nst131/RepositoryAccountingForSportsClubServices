using System.Threading.Tasks;

namespace RabbitMQLibrary
{
    public interface IEventBus
    {
        Task Publish<T>(T @event)
            where T : class;
    }
}