namespace Module8.Z1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DeleteFileAndDir("C:\\Temp\\");
        }

        static void DeleteFileAndDir(string dirName)
        {
            try
            {
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории каталога
                    foreach (string d in dirs) //Проход всех подкаталогов (рекурсивный)
                        DeleteFileAndDir(d);

                    string[] files = Directory.GetFiles(dirName);// Получим все файлы каталога

                    foreach (string s in files)   // Выведем их все
                    {
                        var fileInfo = new FileInfo(s);
                        if (fileInfo.LastAccessTime + TimeSpan.FromMinutes(30) < DateTime.Now)
                            File.Delete(s);//Удаление файла
                    }

                    files = Directory.GetFiles(dirName);// Получим все файлы каталога
                    if (files.Count() == 0)
                        Directory.Delete(dirName);//Удаление пустой папки

                } else
                {
                    Console.WriteLine("Каталог не найден: " + dirName + "!");
                }
            } catch
            {
                Console.WriteLine("Критический сбой при обработке директории: " + dirName + "!");
            }
        }


    }
}