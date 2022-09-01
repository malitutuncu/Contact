using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IUserReportService
    {
        void RequestReportAsync(Guid userId);
    }
}
