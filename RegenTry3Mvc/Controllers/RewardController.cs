using Microsoft.AspNetCore.Mvc;
using RegenTry3.Model;
using RegenTry3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Controllers
{
    public class RewardController : Controller
    {
        private readonly IRewardService rewardService;

        public RewardController(IRewardService rewardService)
        {
            this.rewardService = rewardService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get(int id)
        {
            Reward reward = rewardService.ReadReward(id).Data;

            if (reward == null) return NotFound();
            return View(reward);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Reward reward)
        {
            rewardService.CreateReward(reward);

            return RedirectToAction("../Project/Get");
        }
    }
}
