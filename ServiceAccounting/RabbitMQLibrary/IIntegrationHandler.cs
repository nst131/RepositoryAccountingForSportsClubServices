using System.Threading.Tasks;

namespace RabbitMQLibrary
{
    public interface IIntegrationHandler<in T>
        where T : class
    {
        Task Handle(T @event);
    }
}