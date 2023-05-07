namespace Module8.Z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int iFileDelCount = 0;
            int iPathSize = GetSizeDir("C:\\Temp\\");
            Console.WriteLine("Исходный размер папки: " + iPathSize + " байт.");
            DeleteFileAndDir("C:\\Temp\\", ref iFileDelCount);
            int iPathSizeResult = GetSizeDir("C:\\Temp\\");
            Console.WriteLine("Освобождено: " + (iPathSize - iPathSizeResult) + " байт.");
            Console.WriteLine("Текущий размер папки: " + iPathSizeResult + " байт.");
            Console.WriteLine("Количество файлов удалено: " + iFileDelCount + " шт.");
        }

        static void DeleteFileAndDir(string dirName, ref int iFileDelCount)
        {
            try
            {
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории каталога
                    foreach (string d in dirs) //Проход всех подкаталогов (рекурсивный)
                        DeleteFileAndDir(d, ref iFileDelCount);

                    string[] files = Directory.GetFiles(dirName);// Получим все файлы каталога

                    foreach (string s in files)   // Выведем их все
                    {
                        var fileInfo = new FileInfo(s);
                        if (fileInfo.LastAccessTime + TimeSpan.FromMinutes(30) < DateTime.Now)
                        {
                            File.Delete(s);//Удаление файла
                            iFileDelCount++;
                        }
                    }

                    files = Directory.GetFiles(dirName);// Получим все файлы каталога
                    if (files.Count() == 0)
                        Directory.Delete(dirName);//Удаление пустой папки

                }
                else
                {
                    Console.WriteLine("Каталог не найден: " + dirName + "!");
                }
            }
            catch
            {
                Console.WriteLine("Критический сбой при обработке директории: " + dirName + "!");
            }
        }

        static int GetSizeDir(string dirName)
        {
            int iSize = 0;
            try
            {
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории каталога
                    foreach (string d in dirs) //Проход всех подкаталогов (рекурсивный)
                        iSize = iSize + GetSizeDir(d);

                    string[] files = Directory.GetFiles(dirName);// Получим все файлы каталога

                    foreach (string s in files)   // Выведем их все
                    {
                        var fileInfo = new FileInfo(s);
                        iSize = iSize + (int)fileInfo.Length;
                    }
                }
                else
                {
                    Console.WriteLine("Каталог не найден: " + dirName + "!");
                }
            }
            catch
            {
                Console.WriteLine("Критический сбой при обработке директории: " + dirName + "!");
            }
            return iSize;
        }


    }
}