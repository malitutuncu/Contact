using Common.Contracts.Report;

namespace ContactReport.API
{
    public class CreateReportConsumer
    {
        public Task Consume(CreateReportMessage message)
        {
            Console.WriteLine(message.QueueId);

            return Task.CompletedTask;
        }
    }
}
