using Common.Global.API;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserServices.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Success(user);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var users = _userService.GetList();
            return Success(users);
        }

        [HttpPost]
        public IActionResult Add(AddUserDto addDto)
        {
            _userService.Add(addDto);
            return Success();
        }

        [HttpPost]
        public IActionResult Update(UpdateUserDto updateDto)
        {
            _userService.Update(updateDto);
            return Success();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Success();
        }
    }
}
