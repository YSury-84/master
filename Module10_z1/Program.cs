using System;

namespace Module10_z1
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
                Console.Write("Сумма а + b = " + j);
            } catch
            {
                Console.Write("Сумму а + b посчитать невозможно, так как они не являются целыми числами!");
            }

        }

        public interface ISumm
        {
            int Summ(int a, int b);
        }

        public class Summa : ISumm
        {
            public int Summ(int a, int b)
            {
                return a + b;
            }
        }
    }
}