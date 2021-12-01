using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class Backer : Person
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public List<Project> Projects { get; set; }

        public List<Reward> Rewards { get; set; }

        public virtual List<BackerProject> BackerProjects { get; set; }

        public virtual List<BackerReward> BackerRewards { get; set; }
    }
}
