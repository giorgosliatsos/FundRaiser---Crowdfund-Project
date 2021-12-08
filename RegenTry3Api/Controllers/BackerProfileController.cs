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
    public class BackerProfileController : ControllerBase
    {
        private readonly IBackerService backerService;

        public BackerProfileController(IBackerService backerService)
        {
            this.backerService = backerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Backer> Get()
        {
            return backerService.GetBacker().Data;
        }


        // GET: api/BackerProfile/5
        [HttpGet("{id}")]
        public Backer Get(int id)
        {
            return backerService.GetBacker(id).Data;
        }

        
    }
}
