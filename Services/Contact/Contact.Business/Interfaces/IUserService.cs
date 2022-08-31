using Contact.Business.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Interfaces
{
    public interface IUserService
    {
        UserDto GetById(Guid id);
        List<UserDto> GetList();
        void Add(AddUserDto dto);
        void Delete(Guid id);
        void Update(UpdateUserDto dto);
    }
}
