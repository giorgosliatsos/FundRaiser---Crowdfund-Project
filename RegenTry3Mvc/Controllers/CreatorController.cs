using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;

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
            if (!(creatorService.CreatorExists(creator).Data)) creatorService.CreateCreator(creator);
            return RedirectToAction(nameof(Index), "Project", new { Username = creator.Username });
        }









    }
}
