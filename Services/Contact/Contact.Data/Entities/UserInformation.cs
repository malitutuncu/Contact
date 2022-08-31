using Contact.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
