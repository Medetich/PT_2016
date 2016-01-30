using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a, b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex(c1.a + c2.a, c1.b + c2.b);
            return c3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c = new Complex(5, 6);
            Complex d = new Complex(5, 7);
            Complex w = c + d + c + d + c + d;
            Console.WriteLine(w);
            Console.ReadKey();
        }
    }
