using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakee
{
    class Scoreregister
    {
        public static void scoreregister()
        {
            Console.SetCursorPosition(4, 2);
            Console.Write("Score:" + Snake1.score + "                  " + " Level: " + Wall.lvl);
        }
    }
}
