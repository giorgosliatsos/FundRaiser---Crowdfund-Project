using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegenTry3.Model;
using RegenTry3.Service;

namespace RegenTry3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IBackerService backerService;
        private readonly ICreatorService creatorService;

        public UserProfileController(IBackerService backerService, ICreatorService creatorService)
        {
            this.backerService = backerService;
            this.creatorService = creatorService;
        }

        [HttpGet("/ping")]
        public string Ping()
        {
            return "it works";
        }

        // GET: api/CreatorProfile/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            if (HttpContext.Request.Cookies["Role"].ToString() == "Creator") return creatorService.GetCreator(id).Data;
            else if (HttpContext.Request.Cookies["Role"].ToString() == "Backer") return backerService.GetBacker(id).Data;
            else return null;
         }

        
    }
}
