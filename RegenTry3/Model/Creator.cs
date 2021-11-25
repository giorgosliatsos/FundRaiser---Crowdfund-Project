using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class Creator //maybe not
    {
        public int Id { get; set; } 
        public string Username { get; set; } 

        public List<Project> Projects { get; set; }
    };

}
        