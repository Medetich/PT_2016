using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theory2
{
    public class RecursiveFileSearch
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        static void Main()
        {
            // Начните с драйвов если нужно исследовать весь копьютер.
            string[] drives = System.Environment.GetLogicalDrives();

            foreach (string dr in drives)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

                // Здесь мы пропускаем драйв если нет необходимости его читать.
                // Во многих случаях это действием является неподходящим.
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                System.IO.DirectoryInfo rootDir = di.RootDirectory;
                WalkDirectoryTree(rootDir);
            }

            // Выписывает все файлы требующие обработки.
            Console.WriteLine("Files with restricted access:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }   
            // Содержит консоль в режиме отладки.
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // Сначала обрабатывает все файлы внутри этой папки.
            try
            {
                files = root.GetFiles("*.*");
            }
            // Выполняется даже если один из файлов требует разрешения большей степени чем обеспечивает приложение.
            catch (UnauthorizedAccessException e)
            {
                // Этот код просто выписывает сообщение и продолжает рекурсировать.
                // Можно попробывать что-нибудь другое. 
                // Например, можно попробывать повысить свои привелегиии и добраться до файла снова.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // В этом примере мы только получаем доступ к существующему FileInfo object.
                    // Если мы хотим открыть, изменить или модифицировать файл, тогда
                    // рекомендуется блок "try-catch" чтоб решить задачу где файл
                    // был удален после вызова TraverseTree().
                    Console.WriteLine(fi.FullName);
                }

                // Теперь найдем подфайлы под этим файлом.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Рекурсивный вызов для всех подфайлов.
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
    }
}
