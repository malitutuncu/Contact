using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Global.API
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        [NonAction]
        public IActionResult Success(object responseObject = null)
        {
            return StatusCode(200, responseObject);
        }
    }
}
