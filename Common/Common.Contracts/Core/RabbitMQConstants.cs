using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Core
{
    public class RabbitMQConstants
    {
        public const string Uri = "amqp://guest:guest@localhost:5672"; //"amqps://pqyvmkrk:HnMKX0UnXEzHXQ-LOgyzz1f-Jv9UF-FN@hawk.rmq.cloudamqp.com/pqyvmkrk"; //;
        public const string Username = "guest"; //"pqyvmkrk";
        public const string Password = "guest"; //"HnMKX0UnXEzHXQ-LOgyzz1f-Jv9UF-FN"; 
        public const string Host = "localhost";

        public const string CreateReportQueueName = "createReportQueue";
    }
}
