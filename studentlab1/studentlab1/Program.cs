using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentlab1
{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;
        public string id;


        public Student(string name, string surname, double gpa, string id)
        {
            this.name = name;
            this.surname = surname;
            this.gpa = gpa;
            this.id = id;
        }

        public override string ToString()
        {
            return name + " " + surname + " " + gpa + " " + id;
        }

    class Program
    {
        static void Main(string[] args)
        {
            Student m = new Student("Medet", "Kassymov", 2.11, "15BD02016");
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
}