using Common.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Report
{
    public static class CreateReportPublisher
    {
        async public static Task PublishAsync(Guid reportId)
        {
            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMQConstants.Uri}/{RabbitMQConstants.CreateReportQueueName}");

            var endpoint = bus.GetSendEndpoint(sendToUri).Result;

            var message = new CreateReportMessage
            {
                ReportId = reportId
            };

            await endpoint.Send(message);


            //await bus.StartAsync();
            //await bus.Publish(message);
        }
    }
}
