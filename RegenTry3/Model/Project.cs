using System;
using System.Collections.Generic;
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
        public int Photos { get; set; }

        public int Videos { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reward> Rewards { get; set; }

        public List<Backer> Backers { get; set; }

        public decimal MoneyEarned { get; set; }

        public Creator Creator { get; set; }

        virtual public List<BackerProject> BackerProjects { get; set; }
    }
}
