using static Module9_2.Program;

namespace Module9_2
{
    internal class Program
    {
        static class Pipl
        {
            public static List<string> people = new List<string>() { "Петров", "Сидоров", "Иванов", "Медведев", "Шариков" };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ProcessBusinessLogic blTSort = new ProcessBusinessLogic();
            blTSort.TSort += bl_TSort; // регистрируем событие
            ProcessBusinessLogic blFSort = new ProcessBusinessLogic();
            blFSort.FSort += bl_FSort; // регистрируем событие
            while (true)
            {
                Console.Write("Введите команду: ");
                string s = Console.ReadLine();
                if (s == "exit") break;
                else
                if (s == "1") { blTSort.StartSort(true); }
                else
                if (s == "2") { blFSort.StartSort(false); }
                else
                { Console.Write("Команда не распознана!"); }
            }
        }

        public delegate void Notify();  // делегат
        public class ProcessBusinessLogic
        {
            public event Notify TSort; // событие
            public event Notify FSort; // событие

            public void StartSort(bool bSort)
            {
                if (bSort)
                { TSort(); }
                else
                { FSort(); }
            }

            protected virtual void OnTSort()
            {
                TSort?.Invoke();
            }
            protected virtual void OnFSort() 
            {
                FSort?.Invoke();
            }
        }

        // перехватчик событий
        public static void bl_TSort()
        {
            Console.WriteLine("Sort is True");
            Pipl.people.Sort();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Pipl.people[i]);
            }
        }

        // перехватчик событий
        public static void bl_FSort()
        {
            Console.WriteLine("Sort is False");
            Pipl.people.Sort();
            for (int i = 4; i >=0; i--)
            {
                Console.WriteLine(Pipl.people[i]);
            }
        }

    }
}