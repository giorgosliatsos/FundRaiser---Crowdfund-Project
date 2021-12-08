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
    public class CreatorProfileController : ControllerBase
    {
        private readonly ICreatorService creatorService;

        public CreatorProfileController(ICreatorService creatorService)
        {
            this.creatorService = creatorService;
        }



        // GET: api/CreatorProfile/5
        [HttpGet("{id}")]
        public Creator Get(int id)
        {
            return creatorService.GetCreator(id).Data;
        }

        // GET: api/CreatorProfile/5



    }
}
