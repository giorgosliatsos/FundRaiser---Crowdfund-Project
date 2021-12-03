using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string Photos { get; set; }

        public string Videos { get; set; }

        public string Posts { get; set; }
        public List<Reward> Rewards { get; set; }

        public List<Backer> Backers { get; set; }

        public decimal MoneyGoal { get; set; } // Money Target

        public Creator Creator { get; set; }

        virtual public List<BackerProject> BackerProjects { get; set; }
    }
}
