using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Report
{
    public class CreateReportMessage
    {
        public CreateReportMessage(Guid reportId)
        {
            ReportId = reportId;
        }
        public Guid ReportId { get; set; }
        public Guid QueueId { get; set; } = Guid.NewGuid();
        public DateTime publishData { get; set; } = DateTime.Now;
    }
}
