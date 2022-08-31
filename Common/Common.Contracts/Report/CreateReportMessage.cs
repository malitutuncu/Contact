using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Report
{
    public class CreateReportMessage
    {
        public Guid ReportId { get; set; }
        public Guid QueueId { get; set; } = new Guid();
        public DateTime publishData { get; set; } = new DateTime();
    }
}
