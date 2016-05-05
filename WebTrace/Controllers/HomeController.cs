using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebTrace.Controllers
{
    public class LogController : HubController

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public IActionResult ReceiveMessage()
        {
            return Ok();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
