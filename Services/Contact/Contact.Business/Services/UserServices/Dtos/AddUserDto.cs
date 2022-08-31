using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserServices.Dtos
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

    }
}
