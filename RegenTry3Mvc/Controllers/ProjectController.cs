﻿using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public IActionResult Index()
        {
            List<Project> projects = projectService.ReadProject().Data;
            return View(projects);
        }

        public IActionResult Get(int id)
        {
            Project project = projectService.ReadProject(id).Data;

            if (project == null) return NotFound();
            return View(project);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            projectService.CreateProject(project);

            return RedirectToAction(nameof(Index));
        }






    }
}