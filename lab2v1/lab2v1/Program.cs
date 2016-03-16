using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2v1
{
    class lab2v1
    {
        static void Main(string[] args)
        {
            FileStream fsi = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fso = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader rs = new StreamReader(fsi);
            StreamWriter sw = new StreamWriter(fso);
            string[] massive = rs.ReadLine().Split();

            int min = int.Parse(massive[0]);
            int max = int.Parse(massive[0]);

          
            for (int i = 0; i < massive.Length; i++)
            {
                int a = int.Parse(massive[i]);
                if (a < min)
                    min = a;
                if (a > max)
                    max = a;
            }

            Console.WriteLine(max + " " + min);
            sw.WriteLine(max + " " + min);

            sw.Close();
            rs.Close();
            fsi.Close();
            fso.Close();
            Console.ReadKey();
        }
    }
}