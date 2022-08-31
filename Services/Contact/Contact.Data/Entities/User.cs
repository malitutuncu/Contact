using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<UserInformation> Informations { get; set; }
    }
}
