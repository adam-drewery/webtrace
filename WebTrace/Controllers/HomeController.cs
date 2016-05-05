using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;

namespace WebTrace.Controllers
{
    public class LogController : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
