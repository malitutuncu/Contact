using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Core
{
    public static class MassTransitExtension
    {
        public const string uri = "amqp://guest:guest@localhost:5672";
        public static IServiceCollection AddMassTransitConfiguration(this IServiceCollection services)
        {
            services.AddMassTransit(configurator =>
            {
                configurator.UsingRabbitMq((context, _configurator) =>
                {
                    _configurator.Host(new Uri(uri));

                });
            });

            return services;
        }
    }
}
