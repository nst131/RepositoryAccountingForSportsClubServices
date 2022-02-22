using System;

namespace RabbitMQLibrary
{
    internal class Subscription
    {
        public Type HandleType { get; set; }

        public Type ConsumerType { get; set; }

        public SubscriptionOptions Options { get; set; }

        private Subscription(Type handelType, Type consumerType, SubscriptionOptions options)
        {
            this.HandleType = handelType;
            this.ConsumerType = consumerType;
            this.Options = options;
        }

        public static Subscription Create<T, TH>(SubscriptionOptions options)
            where T : class
            where TH : IIntegrationHandler<T>
        {
            return new Subscription(typeof(TH), typeof(MassTransitConsumer<T, TH>), options);
        }
    }
}