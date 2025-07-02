using System;
using System.Collections.Generic;
using GreenPipes;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace RabbitMQLibrary
{
    internal class SubscriptionRegistration
    {
        private readonly IDictionary<SubscriptionType, Action<Subscription>> registartionOptions;

        private readonly IServiceProvider serviceProvider;
        private readonly IRabbitMqBusFactoryConfigurator cfg;
        private readonly IRabbitMqHost host;

        public SubscriptionRegistration(
            IRabbitMqBusFactoryConfigurator cfg,
            IRabbitMqHost host,
            IServiceProvider provider)
        {
            this.registartionOptions = new Dictionary<SubscriptionType, Action<Subscription>>
            {
                {SubscriptionType.Queue, this.RegisterAsQueue},
                {SubscriptionType.PublishSubscribe, this.RegisterAsPublishSubscribe}
            };

            this.cfg = cfg;
            this.serviceProvider = provider;
            this.host = host;
        }

        public void Register(Subscription subscription)
        {
            if (this.registartionOptions.ContainsKey(subscription.Options.RegistrationType))
            {
                this.registartionOptions[subscription.Options.RegistrationType](subscription);

                return;
            }

            throw new NotImplementedException($"Registration type {subscription.Options.RegistrationType} not supported.");
        }

        private void RegisterAsQueue(Subscription subscription)
        {
            this.cfg.ReceiveEndpoint(
                this.host,
                subscription.HandleType.FullName,
                e =>
                {
                    e.ConfigureConsumer(serviceProvider, subscription.ConsumerType);

                    if (subscription.Options.ConcurrencyLimits.HasValue)
                    {
                        e.UseConcurrencyLimit(subscription.Options.ConcurrencyLimits.Value);
                    }
                });
        }

        private void RegisterAsPublishSubscribe(Subscription subscription)
        {
            var queueName = $"{subscription.HandleType.FullName}_{Guid.NewGuid()}";

            this.cfg.ReceiveEndpoint(
                this.host,
                queueName,
                e =>
                {
                    e.AutoDelete = true;
                    e.PrefetchCount = subscription.Options.PrefetchCount ?? 1000;
                    e.PurgeOnStartup = true;
                    e.ConfigureConsumer(serviceProvider, subscription.ConsumerType);
                    if (subscription.Options.ConcurrencyLimits.HasValue)
                    {
                        e.UseConcurrencyLimit(subscription.Options.ConcurrencyLimits.Value);
                    }
                });
        }
    }
}