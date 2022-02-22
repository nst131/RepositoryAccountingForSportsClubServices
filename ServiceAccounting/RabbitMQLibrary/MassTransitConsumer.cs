using System.Threading.Tasks;
using MassTransit;

namespace RabbitMQLibrary
{
    internal class MassTransitConsumer<TEvent, THandler> : IConsumer<TEvent>
        where THandler : IIntegrationHandler<TEvent>
        where TEvent : class
    {
        private readonly THandler handler;

        public MassTransitConsumer(THandler handler)
        {
            this.handler = handler;
        }

        public async Task Consume(ConsumeContext<TEvent> context)
        {
            await this.handler.Handle(context.Message);
        }
    }
}