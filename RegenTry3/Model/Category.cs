using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public enum Category
    {
        [Description ("Comics")]
        COMICS,
        [Description("Design")]
        DESIGN,
        [Description("Film")]
        FILM,
        [Description("Food")]
        FOOD,
        [Description("Games")]
        GAMES,
        [Description("Music")]
        MUSIC,
    }
}
