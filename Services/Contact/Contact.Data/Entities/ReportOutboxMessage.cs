using Contact.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{
    public class ReportOutboxMessage : IEntity
    {
        public Guid Id { get; set; }
        public DateTime OccuredOn { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}
