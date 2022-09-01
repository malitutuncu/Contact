using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Core
{
    public class RabbitMQConstants
    {
        public const string Uri =  "amqps://pqyvmkrk:HnMKX0UnXEzHXQ-LOgyzz1f-Jv9UF-FN@hawk.rmq.cloudamqp.com/pqyvmkrk"; //"amqp://guest:guest@localhost:5672";
        public const string Username = "pqyvmkrk"; //"guest"
        public const string Password = "HnMKX0UnXEzHXQ-LOgyzz1f-Jv9UF-FN"; //"guest"

        public const string CreateReportQueueName = "createReport";
    }
}
