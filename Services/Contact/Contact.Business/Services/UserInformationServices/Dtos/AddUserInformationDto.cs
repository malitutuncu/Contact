using Contact.Data.Entities;
using Contact.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserInformationServices.Dtos
{
    public class AddUserInformationDto
    {
        public Guid UserId { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
    }
}
