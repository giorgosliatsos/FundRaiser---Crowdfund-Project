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
            if (!(backerService.BackerExists(backer).Data)) backerService.CreateBacker(backer);
            return RedirectToAction(nameof(Index), "Project", new { Username = backer.Username });
        }

    }
}
