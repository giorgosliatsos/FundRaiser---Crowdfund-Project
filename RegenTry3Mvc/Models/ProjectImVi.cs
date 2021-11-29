using Microsoft.AspNetCore.Http;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Models
{
    public class ProjectImVi
    {
        public Project Project { get; set; }

        public IFormFile ProjectImage { get; set; }

        public IFormFile ProjectVideo { get; set; }
    }
}
