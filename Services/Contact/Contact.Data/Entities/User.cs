using Contact.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<UserInformation> Informations { get; set; }

        public virtual ICollection<UserReport> Reports { get; set; }
    }
}
