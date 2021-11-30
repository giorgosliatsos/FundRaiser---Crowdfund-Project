using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RegenTry3Mvc.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectService projectService;
        
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }


        public IActionResult Index(IFormCollection formCollection)
        {
            
            TempData["Username"] = HttpContext.Request.Cookies["Username"];
            TempData["Id"] = HttpContext.Request.Cookies["Id"];
            TempData["Role"] = HttpContext.Request.Cookies["Role"];

            int categoryId = 0;
            if (formCollection["category"].Count() > 0) categoryId = Int32.Parse(formCollection["category"].ToString());
            List<Project> projects = projectService.ReadProjectByCategory(categoryId, Int32.Parse(HttpContext.Request.Cookies["Id"])).Data;
            return View(projects);
        }

        public IActionResult Get(int id)
        {
            Project project = projectService.ReadProject(id).Data;

            if (project == null) return NotFound();
            HttpContext.Response.Cookies.Append("ProjectId", id.ToString());
            return View(project);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            projectService.CreateProject(project,Int32.Parse(HttpContext.Request.Cookies["Id"]));

            return RedirectToAction(nameof(Index));
     
        }






    }
}
