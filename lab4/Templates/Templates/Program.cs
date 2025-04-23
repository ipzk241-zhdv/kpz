using System;
using System.IO;
using Templates.Composite;

namespace Templates
{
    class Program
    {
        static void Main()
        {
            Observer();
        }

        static void Observer()
        {
            var button = new LightElementNode("button", DisplayType.Inline);
            button.AddChild(new LightTextNode("Click me"));

            var cacheObs = new CacheObserver();
            var counterObs = new CounterObserver();

            button.AddEventListener("click", cacheObs);
            button.AddEventListener("click", counterObs);
            button.AddEventListener("mouseover", counterObs);

            Console.WriteLine("== HTML ==");
            Console.WriteLine(button.OuterHTML);
            Console.WriteLine();

            Console.WriteLine("== Симуляція подій ==");
            Console.WriteLine("\nDispatch click(1):");
            button.DispatchEvent("click", 1);

            Console.WriteLine("\nDispatch click(2):");
            button.DispatchEvent("click", 2);

            Console.WriteLine("\nDispatch mouseover(0):");
            button.DispatchEvent("mouseover", 0);

            Console.WriteLine("\n== DisplayInfo ==");
            cacheObs.DisplayInfo();
            counterObs.DisplayInfo();
        }
    }
}
