using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void LookIn(string path)
        {
            Stack<string> drs = new Stack<string>();
            drs.Push(path);
            while (drs.Count > 0)
            {
                DirectoryInfo current = new DirectoryInfo(drs.Pop());
                DirectoryInfo[] subdrs = current.GetDirectories();
                FileInfo[] files = current.GetFiles();
                Console.WriteLine(current);
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file);
                }
                foreach (DirectoryInfo s in subdrs)
                {
                    drs.Push(s.FullName);
                }
            }

        }
        static void Main(string[] args)
        {
            LookIn(@"C:\WORK\far 2.0\");
            Console.ReadKey();
        }
    }
}