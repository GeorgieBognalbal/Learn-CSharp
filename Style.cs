using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject
{
    public class Style
    {
        // -- RESET
        public string RESET = "\u001b[0m";

        // -- TEXT COLOR
        public string RED = "\u001b[31m";
        public string GREEN = "\u001b[32m";
        public string YELLOW = "\u001b[33m";
        public string BLUE = "\u001b[34m";
        public string MAGENTA = "\u001b[35m";
        public string CYAN = "\u001b[36m";
        public string WHITE = "\u001b[37m";
        public string BLACK = "\u001b[30m";

        // -- BACKGROUND COLOR    
        public string RED_BG = "\u001b[41m";
        public string GREEN_BG = "\u001b[42m";
        public string YELLOW_BG = "\u001b[43m";
        public string BLUE_BG = "\u001b[44m";
        public string MAGENTA_BG = "\u001b[45m";
        public string CYAN_BG = "\u001b[46m";
        public string WHITE_BG = "\u001b[47m";
        public string BLACK_BG = "\u001b[40m";

        public string setColor(string color, object text)
        {
            return color + text + RESET;
        }
    }
}
