using System.Threading.Tasks;
using MassTransit;

namespace RabbitMQLibrary
{
    internal sealed class RabbitMqEventBus : IEventBus
    {
        private readonly IBus bus;

        public RabbitMqEventBus(IBus bus)
        {
            this.bus = bus;
        }

        public async Task Publish<T>(T @event)
            where T : class
        {
            await this.bus.Publish(@event, @event.GetType());
        }
    }
}