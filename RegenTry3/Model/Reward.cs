using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class Reward
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public Project Project { get; set; }

        public List<Backer> Backers { get; set; }

        public virtual List<BackerReward> BackerRewards { get; set; }
    }
}
