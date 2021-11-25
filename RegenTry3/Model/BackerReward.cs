using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class BackerReward
    {
        public int Id { get; set; }

        public Backer Backer { get; set; }

        public Reward Reward { get; set; }
    }
}
