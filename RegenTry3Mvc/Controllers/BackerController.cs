using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Controllers
{
    public class BackerController : Controller {

        private readonly IBackerService backerService;

        public BackerController(IBackerService backerService)
        {
            this.backerService = backerService;
        }


        public IActionResult Index()
        {
            return RedirectToAction(nameof(Log));
        }

        public IActionResult Log()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log(Backer backer)
        {
            int backerId = backerService.FindBackerId(backer.Username).Data;
            if (backerId < 0)
            {
                var newBacker = backerService.CreateBacker(backer).Data;
                backerId = backerService.FindBackerId(newBacker.Username).Data;
            }

            HttpContext.Response.Cookies.Append("Id", backerId.ToString());
            HttpContext.Response.Cookies.Append("Username", backer.Username);
            HttpContext.Response.Cookies.Append("Role", "Backer");

            return RedirectToAction("BackerIndex", "Project", null);
        }

    }
}
