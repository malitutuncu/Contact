using Contact.Data.Context;
using Contact.Data.Core;
using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
