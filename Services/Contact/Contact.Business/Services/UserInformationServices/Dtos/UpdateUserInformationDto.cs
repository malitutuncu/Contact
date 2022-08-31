using Contact.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserInformationServices.Dtos
{
    public class UpdateUserInformationDto
    {
        public Guid Id { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
    }
}
