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

            Console.WriteLine("\n==== Memento ====");
            Memento();
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

        static void Memento()
        {
            var editor = new TextEditor();
            var caretaker = new Caretaker(editor);

            editor.Write("First line.\n");
            caretaker.Backup();

            editor.Write("Second line.\n");
            caretaker.Backup();

            editor.Write("Third line.\n");

            Console.WriteLine("=== Current Document ===");
            editor.Print();

            Console.WriteLine();
            caretaker.RenderSnapshotList();

            Console.WriteLine("\n--- Performing Undo #1 ---");
            caretaker.Undo();
            editor.Print();

            Console.WriteLine("\n--- Performing Undo #2 ---");
            caretaker.Undo();
            editor.Print();
        }
    }
}
