using Contact.Business.Services.UserServices.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserServices.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserDto>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(100);
        }
    }
}
