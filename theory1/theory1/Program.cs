using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theory1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Простой массив
            int[] array1 = new int[5];
 
            // Заполнение массива
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
 
            // Альтернатива заполнения массива выше
            int[] array3 = { 1, 2, 3, 4, 5, 6 };
 
            // Двумерный массив
            int[,] multiDimensionalArray1 = new int[2, 3];
 
            // Заполнение массива
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
 
            // Двумерный массив без конкретного числа
            int[][] jaggedArray = new int[6][];

            // Задача строки
            string message1;
            
            // Инициализация в null
            string message2 = null;
            
            // Инициализация в виде пустой строки
            string message3 = System.String.Empty;
            
            //Инициализация в виде строки
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";
            
            // Символ "@" требуется для корректного считывания адреса
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";
            
            // Задача стринга
            System.String greeting = "Hello world";
            
            // Переводит переменную в тип стринг
            var temp = "15BD02016";
            
            // Constant
            const string message = "PT_2016";
            
            // Массив из символов
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);
            
            string s1 = "It is very ";
            string s2 = "sunny today.";
            
            // Соединение предыдущих строк
            s1 += s2;
            
            System.Console.WriteLine(s1);
            
            // Объединенную версия
            
            string s10 = "Hello ";
            string s20 = s1;
            s1 += "World";
            
            System.Console.WriteLine(s20);// с20 принимает данные с10
            
            string filePath = @"C:\Users\scoleridge\Documents\";
            // Вывод ссылки
            
            string text = @"Today I 
            have eaten a 
            lot of icecream.";
            
            /* Вывод:
             Today I 
             have eaten a 
             lot of icecream. 
            
            
            string quote = @"His name is ""Medet.""";
            
            //Вывод: 
            His name was "Medet."
            Console.ReadKey();
            */
        }
    }
}
