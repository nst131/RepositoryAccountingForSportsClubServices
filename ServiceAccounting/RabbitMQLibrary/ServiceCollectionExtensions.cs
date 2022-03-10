using System;
using System.Collections.Generic;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQLibrary
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services, Action<IRabbitMqHostConfigurator> configure)
        {
            var configurator = new RabbitMqConfigurator(services);
            configure(configurator);
            configurator.Configure();

            return services;
        }

        private class RabbitMqConfigurator : IRabbitMqHostConfigurator, IEventBusConfigurator
        {
            private readonly IServiceCollection services;
            private readonly List<Subscription> subcriptions;
            private RabbitMqOptions rabbitMqOptions;

            public RabbitMqConfigurator(IServiceCollection services)
            {
                this.services = services;
                this.subcriptions = new List<Subscription>();
            }

            public IEventBusConfigurator UseRabbitMq(RabbitMqOptions options)
            {
                this.rabbitMqOptions = options;

                return this;
            }

            public IEventBusConfigurator Subscribe<T, TH>(SubscriptionOptions options)
                where T : class
                where TH : IIntegrationHandler<T>
            {
                this.subcriptions.Add(Subscription.Create<T, TH>(options));

                return this;
            }

            public IEventBusConfigurator Subscribe<T, TH>(SubscriptionType type = SubscriptionType.Queue)
                where T : class
                where TH : IIntegrationHandler<T>
            {
                var options = new SubscriptionOptions
                {
                    RegistrationType = type
                };

                this.subcriptions.Add(Subscription.Create<T, TH>(options));

                return this;
            }

            public void Configure()
            {
                this.services.AddMassTransitHostedService();

                this.services.AddMassTransit(c =>
                {
                    foreach (var subscription in subcriptions)
                    {
                        c.AddConsumer(subscription.ConsumerType);
                    }

                    c.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var host = cfg.Host(
                            new Uri(this.rabbitMqOptions.Host),
                            h =>
                            {
                                h.Username(this.rabbitMqOptions.User);
                                h.Password(this.rabbitMqOptions.Password);
                            });

                        var registration = new SubscriptionRegistration(cfg, host, provider);

                        foreach (var subscription in subcriptions)
                        {
                            registration.Register(subscription);
                        }

                        cfg.UseHealthCheck(provider);
                    }));
                });

                foreach (var subscription in subcriptions)
                {
                    this.services.AddScoped(subscription.HandleType);
                }

                this.services.AddSingleton<IEventBus, RabbitMqEventBus>();
            }
        }
    }
}
