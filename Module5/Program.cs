namespace Module5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Цикл for");

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(i);

                    Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
                    var color = Console.ReadLine();

                    switch (color)
                    {
                        case "red":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is red!");
                            break;

                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is green!");
                            break;
                        case "cyan":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is cyan!");
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Your color is yellow!");
                            break;
                    }
                }

                Console.WriteLine("Цикл while");
                int k = 0;
                while (k < 3)
                {
                    Console.WriteLine(k);

                    Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
                    var color = Console.ReadLine();

                    switch (color)
                    {
                        case "red":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is red!");
                            break;

                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is green!");
                            break;
                        case "cyan":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is cyan!");
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Your color is yellow!");
                            break;
                    }
                }

                Console.WriteLine("Цикл do");
                int t = 0;

                do
                {
                    Console.WriteLine(t);

                    Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
                    var color = Console.ReadLine();

                    switch (color)
                    {
                        case "red":
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is red!");
                            break;

                        case "green":
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is green!");
                            break;
                        case "cyan":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.WriteLine("Your color is cyan!");
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Your color is yellow!");
                            break;
                    }

                } while (t < 3);

                Console.ReadKey();
            }
    }
}