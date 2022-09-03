using Common.Contracts.Report;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactReport.Console.App
{
    public class CreateReportConsumer : IConsumer<CreateReportMessage>
    {
        public async Task Consume(ConsumeContext<CreateReportMessage> context)
        {
            string jsonString = JsonSerializer.Serialize(context.Message);

            System.Console.WriteLine($"message: {jsonString}");
        }
    }
}
