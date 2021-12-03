using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenTry3Mvc.Models
{
    public class ProjectReward
    {

        public ProjectReward(Project project, List<Reward> rewards)
        {
            Project = project;
            Rewards = rewards;
        }

        public Project Project { get; set; }

        public List<Reward> Rewards { get; set; }
    }
}
