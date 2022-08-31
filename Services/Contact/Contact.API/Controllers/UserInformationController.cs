using Common.Global.API;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserServices.Dtos;
using Contact.Business.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Contact.Business.Services.UserInformationServices.Dtos;

namespace Contact.API.Controllers
{
    public class UserInformationController : BaseController
    {
        private readonly IUserInformationService _userInformationService;
        public UserInformationController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            var user = _userInformationService.GetById(id);
            return Success(user);
        }

        [HttpGet]
        public IActionResult GetListByUserId(Guid id)
        {
            var users = _userInformationService.GetListByUserId(id);
            return Success(users);
        }

        [HttpPost]
        public IActionResult Add(AddUserInformationDto addDto)
        {
            _userInformationService.Add(addDto);
            return Success();
        }

        [HttpPost]
        public IActionResult Update(UpdateUserInformationDto updateDto)
        {
            _userInformationService.Update(updateDto);
            return Success();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _userInformationService.Delete(id);
            return Success();
        }
    }
}
