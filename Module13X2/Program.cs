using System.Collections.Immutable;
using System.Diagnostics;

namespace Module13X2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("C:\\Users\\student\\source\\repos\\YSury-84\\skill\\Module13X2\\Text1.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine(words.Length);

            //-----------------------------------------------------------
            //Задание # 13.6.1 (Оформление в виде классов не требовалось)
            //-----------------------------------------------------------

            var lists = new List<string>();
            var llists = new LinkedList<string>();
            //Test List:
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (string word in words)
                lists.Add(word);
            stopWatch.Stop();
            Console.WriteLine("Скорость List (сл./мсек.): "+ words.Length/stopWatch.ElapsedMilliseconds);
            //Test LinkedList:
            stopWatch.Start();
            foreach (string word in words)
                llists.AddLast(word);
            stopWatch.Stop();
            Console.WriteLine("Скорость List (сл./мсек.): " + words.Length / stopWatch.ElapsedMilliseconds);

            //-----------------------------------------------------------
            //Задание # 13.6.2 (Оформление в виде классов не требовалось)
            //-----------------------------------------------------------
  
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество слов
            Console.WriteLine(words.Length);
            var popularWords = new Dictionary<string, int>();
            foreach (string word in words)
                if (popularWords.ContainsKey(word))
                    popularWords[word] += 1;
                     else
                    popularWords.Add(word, 1);

            var sortedDict = popularWords.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int i=0;
            foreach (var word in sortedDict)
            {  
                if (i+10 >= sortedDict.Count)
                    Console.WriteLine(word);
                i++;
            }
            //-----------------------------------------------------------
        }
    }
}