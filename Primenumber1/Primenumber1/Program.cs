using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primenumber1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            foreach (string s in numbers)
            {
                int a = int.Parse(s);
                bool p = false;
                for (int i = 2; i * i <= a; i++)
                {
                    if (a % i == 0)
                        a = true;
                }
                if (p == false)
                    Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}