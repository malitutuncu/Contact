using Common.Contracts.Report;
using Contact.Data.Entities;
using ContactReport.Outbox.Service.Core;
using MassTransit;
using MassTransit.Transports;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactReport.Outbox.Service
{
    public class CreateReportPublishJob : IJob
    {

        private readonly IPublishEndpoint _publishEndpoint;
        public CreateReportPublishJob(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if (DatabaseManager.isReady() == false) return;

            DatabaseManager.setReadStateBusy();

            var reportOutboxList = await DatabaseManager.GetListAsync<ReportOutboxMessage>("SELECT * FROM report_outbox_table ORDER BY occured_on DESC");

            foreach (var reportOutbox in reportOutboxList)
            {

                var message = JsonSerializer.Deserialize<CreateReportMessage>(reportOutbox.Payload);

                if (message != null)
                {
                    var createReportMessage = new CreateReportMessage(message.ReportId, message.QueueId, message.publishData);

                    await _publishEndpoint.Publish(createReportMessage);

                    await DatabaseManager.ExecuteAsync($"DELETE FROM report_outbox_table WHERE id = '{reportOutbox.Id}'");

                    Console.WriteLine($"publish report {reportOutbox.Id}");
                }

            }

            DatabaseManager.setReadStateReady();
            Console.WriteLine("outbox table checked!");
        }
    }
}
