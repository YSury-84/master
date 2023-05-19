namespace Module10_z2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello, World!");
                Console.Write("Введите число а: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите число b: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Summa summa = new Summa();
                int j = summa.Summ(a, b);
                Console.WriteLine("Сумма а + b = " + j);
                ((ILogger)summa).Write();
            }
            catch
            {
                Console.Write("Сумму а + b посчитать невозможно, так как они не являются целыми числами!");
            }

        }

        public interface ISumm
        {
            int Summ(int a, int b);
        }
        public interface ILogger
        {
            void Write() { Console.WriteLine("Hello! I am Logger!"); }
        }

        public class Summa : ISumm, ILogger
        {
            public int Summ(int a, int b)
            {
                return a + b;
            }
        }
    }
}