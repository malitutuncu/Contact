using Contact.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{
    public class UserReport
    {
        public Guid Id { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public ReportStatus ReportStatus { get; set; } = ReportStatus.Preparing;
        public string ExcelPath { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
