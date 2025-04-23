using System;
using System.IO;

namespace Templates
{
    internal class Program
    {
        public static string currentPath = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            Console.WriteLine("==== Chain of Responsobility ====");
            Chain();

            Console.WriteLine("\n==== Mediator ====");
            Mediator();
            Console.ReadKey();
        }

        static void Chain()
        {
            var support = new SupportSystem();
            support.Start();
        }

        static void Mediator()
        {

        }
    }
}
