
using Common.Contracts.Core;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ContactReport.App
{
    public class CreateReportSubscriber
    {
        
        public void Subscribe()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQConstants.Uri);
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                  //  var message = Encoding.UTF8.GetString(body);
                 //   Console.WriteLine(" Received {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
