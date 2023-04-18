namespace Module5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static int Factorial(int x)
            {
                if (x == 0)
                {
                    return 1;
                }
                else
                {
                    return x * Factorial(x - 1);
                }
            }

            Console.WriteLine(Factorial(20));

            Console.ReadLine();
        }
    }
}