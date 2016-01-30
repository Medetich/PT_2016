using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arraystheory
{
    class TestArraysClass
    {
        static void Main()
        {
            // Задача одномерного массива 
            int[] array1 = new int[4];

            // Задача массива и его данных
            int[] array2 = new int[] { 2, 3, 4, 5 };

            // Альтернативное заполнение
            int[] array3 = { 1, 2, 3, 4, 5, 6 };

            // Задача двумерного массива
            int[,] multiDimensionalArray1 = new int[2, 4];

            // Задача значений массива
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Задача массива у которого нет определенного числа строк и рядов "jagged array"
            int[][] jaggedArray = new int[6][];

            // Задача значений первого массива  в "jagged array"
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
        }
    }
}
