using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Microsoft.Extensions.Hosting;
using RegenTry3Mvc.Models;

namespace RegenTry3Mvc.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectService projectService;
        private readonly IHostEnvironment hostEnvironment;

        public ProjectController(IProjectService projectService, IHostEnvironment hostEnvironment)
        {
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
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
        public IActionResult Create(ProjectImVi projectImVi)
        {
            Project project = projectImVi.Project;
            var img = projectImVi.ProjectImage;

            if (img != null)
            {
                var uniqueFileName = GetUniqueFileName(img.FileName);
                var images = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "images");
                var filePath = Path.Combine(images, uniqueFileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));
                project.Photos = uniqueFileName;
            }
            projectService.CreateProject(project,Int32.Parse(HttpContext.Request.Cookies["Id"]));

            return RedirectToAction(nameof(Index));
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult Delete(int id)
        {
            projectService.DeleteProject(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult UpdatePost(int id)
        {
              return View();
        }

        [HttpPost]
        public IActionResult UpdatePost(int id, string newPost)
        {
            projectService.UpdatePost(id, newPost);
            return RedirectToAction(nameof(Index));
        }



    }
}
