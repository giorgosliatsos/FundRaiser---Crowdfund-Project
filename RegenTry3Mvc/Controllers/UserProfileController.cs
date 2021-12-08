using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfileController
        public ActionResult Index()
        {
            TempData["Role"] = HttpContext.Request.Cookies["Role"].ToString();
            return View();
        }

        public ActionResult Redirect()
        {
            return RedirectToAction("Index",new { id = HttpContext.Request.Cookies["Id"].ToString(), role = HttpContext.Request.Cookies["Role"].ToString() });
        }
    }
}
