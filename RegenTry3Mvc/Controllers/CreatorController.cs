using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System.Web;

namespace RegenTry3Mvc.Controllers
{
    public class CreatorController : Controller
    {

        private readonly ICreatorService creatorService;

        public CreatorController(ICreatorService creatorService)
        {
            this.creatorService = creatorService;
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
        public IActionResult Log(Creator creator)
        {
            int creatorId = creatorService.FindCreatorId(creator.Username).Data;
            if (creatorId <0)
            { 
                var newCreator=creatorService.CreateCreator(creator).Data; 
                creatorId = creatorService.FindCreatorId(newCreator.Username).Data;
            }


            HttpContext.Response.Cookies.Append("Id", creatorId.ToString());
            HttpContext.Response.Cookies.Append("Username", creator.Username);
            HttpContext.Response.Cookies.Append("Role", "Creator");

            return RedirectToAction(nameof(Index), "Project", null);
        }










    }
}
