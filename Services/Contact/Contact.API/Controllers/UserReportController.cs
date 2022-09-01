using Common.Global.API;
using Contact.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    public class UserReportController : BaseController
    {
        private readonly IUserReportService _userReportService;
        public UserReportController(IUserReportService userReportService)
        {
            _userReportService = userReportService;
        }


        [HttpPost]
        public IActionResult RequestReport(Guid userId)
        {
            _userReportService.RequestReportAsync(userId);
            return Success();
        }
    }
}
