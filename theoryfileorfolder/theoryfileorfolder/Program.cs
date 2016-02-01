using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theoryfileorfolder
{
    public class CreateFileOrFolder
    {
        static void Main()
        {
            // Подберите имя для вашего файл.
            string folderName = @"c:\Top-Level Folder";

            // Для создания string котороый определяет путь к подфайлу в
            // файле, добавить имя для подфайла к folderName.
            string pathString = System.IO.Path.Combine(folderName, "SubFolder");

            // Вы можете выписать имя пути прямо вместо использовия Combine method. Combine упрощает задачу.
            string pathString2 = @"c:\Top-Level Folder\SubFolder2";

            // Вы можете вытнуть дальность пути если это требуется.
            //pathString = System.IO.Path.Combine(pathString, "SubSubFolder");

            // Создайте подфайл. Вы можете подтвердить в File Explorer что вы имеете это
            // Структуруа в C: drive.
            //  Локальный диск (C:)
            //   Файл
            //    Подфайл            
            System.IO.Directory.CreateDirectory(pathString);

            // Создайте имя файла для файла котороый вы хотите создать. 
            string fileName = System.IO.Path.GetRandomFileName();

            // Этот пример использует случайный string для имени, но вы также можете задать точное время.
            // string fileName = "MyNewFile.txt";

            // Используйте Combine снова чтобы задать имя файла в путь.
            pathString = System.IO.Path.Combine(pathString, fileName);

            // Verify the path that you have constructed.
            Console.WriteLine("Path to my file: {0}\n", pathString);

            // Убедитесь что файл уже не существует. Если не существует, создайте файл и задайте постоянные 0-29 к нему.
            // ВНИМАНИЕ: System.IO.File.Create перепишет файл если он уже существует.
            // Это может произойти с любым случайным файлом.
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            // Считывает и выводит информацию из файла.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
        // Примерный вывод:

        //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29
    }
}