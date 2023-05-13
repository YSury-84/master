namespace Module9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер исключения:");
            string n = Console.ReadLine();
            int i = 0;
            try
            {
                i = Convert.ToInt32(n);
            }
            catch
            {
                i = 0;
            }
            Exception[] myex = new Exception[5];
            myex[0] = new MyError("Ошибка: Мое собственное исключение!");
            myex[1] = new Exception("Исключение #1");
            myex[2] = new Exception("Исключение #2");
            myex[3] = new Exception("Исключение #3");
            myex[4] = new Exception("Исключение #4");
            myex[1].HelpLink = "www.google.com";
            myex[1].HResult = 1;
            myex[2].HResult = 2;
            myex[3].HResult = 3;
            myex[4].HResult = 4;

            try
            {
                if (i >= 1 && i <= 4)
                {
                    throw myex[i];
                }
                else
                {
                    throw myex[0];
                }
            }
            catch
            {
                Console.WriteLine("Произошло исключение: " + myex[i].Message);
            }
        }

        public class MyError : ArgumentException
        {
            public MyError(string _exeptionMessege) : base(_exeptionMessege)
            { }
        }
    }
}