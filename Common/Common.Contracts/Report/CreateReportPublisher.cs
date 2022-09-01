using Common.Contracts.Core;
using MassTransit;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Contracts.Report
{
    public static class CreateReportPublisher
    {
        public static void PublishAsync(Guid reportId)
        {
            //var bus = BusConfigurator.ConfigureBus();
            //  var sendToUri = new Uri($"{RabbitMQConstants.Uri}/{RabbitMQConstants.CreateReportQueueName}");

            //  var endpoint = bus.GetSendEndpoint(sendToUri).Result;

            var message = new CreateReportMessage(reportId);

            // await endpoint.Send(message);

            // await bus.StartAsync();
            // await bus.Publish(message);

            var factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQConstants.Uri);
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: RabbitMQConstants.CreateReportQueueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string jsonString = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(jsonString);

                channel.BasicPublish(exchange: "",
                                     routingKey: RabbitMQConstants.CreateReportQueueName,
                                     basicProperties: null,
                                     body: body);

            }
        }
    }
}
