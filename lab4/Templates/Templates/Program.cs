using System;
using System.IO;

namespace Templates
{
    class Program
    {
        static void Main()
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
            var runway1 = new Runway("Runway A");
            var runway2 = new Runway("Runway B");

            var aircraft1 = new Aircraft("Boeing 737");
            var aircraft2 = new Aircraft("Airbus A320");

            var commandCentre = new CommandCentre(new[] { runway1, runway2 }, new[] { aircraft1, aircraft2 });

            aircraft1.RequestLanding();
            aircraft2.RequestLanding();

            aircraft1.RequestTakeOff();
            aircraft2.RequestTakeOff();
        }
    }
}
