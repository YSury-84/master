namespace Module8.Z2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Рахмер папки: " + GetSizeDir("C:\\Temp\\") + " байт.");
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