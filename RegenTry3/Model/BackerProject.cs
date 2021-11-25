using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class BackerProject
    {
        public int Id { get; set; }

        public Backer Backer { get; set; }

        public Project Project { get; set; }
    }
}
