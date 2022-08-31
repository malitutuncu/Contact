using Contact.Business.Services.UserInformationServices.Dtos;
using Contact.Business.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IUserInformationService
    {
        UserInformationDto GetById(Guid id);
        List<UserInformationDto> GetListByUserId(Guid id);
        void Add(AddUserInformationDto AddDto);
        void Delete(Guid id);
        void Update(UpdateUserInformationDto updateDto);
    }
}
