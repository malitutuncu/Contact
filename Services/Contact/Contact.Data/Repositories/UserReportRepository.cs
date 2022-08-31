using Contact.Data.Context;
using Contact.Data.Core;
using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class UserReportRepository : GenericRepository<UserReport>, IUserReportRepository
    {
        public UserReportRepository(AppDbContext context) : base(context)
        {
        }
    }
}
