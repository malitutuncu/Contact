using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Core
{
    public class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(configuration =>
            {
                configuration.Host(RabbitMQConstants.Uri, hostConfiguration =>
                {
                    hostConfiguration.Username(RabbitMQConstants.Username);
                    hostConfiguration.Password(RabbitMQConstants.Password);
                });

                registrationAction?.Invoke(configuration);
            });
        }
    }
}
