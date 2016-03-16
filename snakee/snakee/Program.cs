using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    [Serializable]
    public class Program
    {
        public enum Direction { up, down, left, right };
        public static Direction direction;


        static void Main(string[] args)
        {
            Snake.Models.Game snake = new Snake.Models.Game();
            Console.ReadKey();

        }
    }
}
