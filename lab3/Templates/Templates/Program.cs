using System;
using System.IO;
using Templates.Adapter;
using Templates.Bridge;
using Templates.Composite;
using Templates.Decorator;
using Templates.Proxy;

namespace Templates
{
    internal class Program
    {
        public static string currentPath = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            Logger consoleLogger = new Logger();
            consoleLogger.Log("=== Adapter ===");
            Adapter();

            consoleLogger.Log("\n\n=== Decorator ===");
            Decorator();

            consoleLogger.Log("\n\n=== Bridge ===");
            Bridge();

            consoleLogger.Log("\n\n=== Proxy ===");
            Proxy();

            consoleLogger.Log("\n\n=== Composite ===");
            Composite();

            Console.ReadKey();
        }

        public static void Adapter()
        {
            Logger consoleLogger = new Logger();
            consoleLogger.Log("Everything is running smoothly.");
            consoleLogger.Warn("This might be an issue.");
            consoleLogger.Error("Something went wrong!");

            Console.WriteLine("\n=== File Logger via Adapter ===");
            string path = currentPath + "\\adapterLog.txt";
            FileWriter writer = new FileWriter(path);
            IWriterLogger fileLogger = new FileLoggerAdapter(writer);

            fileLogger.Log("File log successful.");
            fileLogger.Warn("File warning message.");
            fileLogger.Error("File error message.");

            Console.WriteLine($"Logs written to file: {path}");
        }

        public static void Decorator()
        {
            IHero hero = new Warrior();
            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");

            hero = new Weapon(hero);
            hero = new Armor(hero);
            hero = new Artifact(hero);

            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");

            IHero mage = new Mage();
            mage = new Artifact(mage);
            mage = new Artifact(mage); // два артефакти
            mage = new Armor(mage);

            Console.WriteLine($"{mage.GetDescription()}, Power: {mage.GetPower()}");
        }

        public static void Bridge()
        {
            IRenderer vector = new VectorRenderer();
            IRenderer raster = new RasterRenderer();

            Shape circle1 = new Circle(vector);
            Shape circle2 = new Circle(raster);

            Shape square = new Square(vector);
            Shape triangle = new Triangle(raster);

            circle1.Draw();     // Drawing Circle as vectors.
            circle2.Draw();     // Drawing Circle as pixels.
            square.Draw();      // Drawing Square as vectors.
            triangle.Draw();    // Drawing Triangle as pixels.
        }

        public static void Proxy()
        {
            string allowedFile = currentPath + "\\allowed.txt";
            string deniedFile = currentPath + "\\secret.log";

            File.WriteAllText(allowedFile, "Hello\nWorld!");
            File.WriteAllText(deniedFile, "This is confidential!");

            ITextReader reader = new SmartTextReader();
            ITextReader loggingProxy = new SmartTextChecker(reader);
            ITextReader secureProxy = new SmartTextReaderLocker(loggingProxy, @"\.log$");

            Console.WriteLine("Reading allowed.txt:");
            secureProxy.ReadText(allowedFile);

            Console.WriteLine("\nReading secret.log:");
            secureProxy.ReadText(deniedFile);
        }

        public static void Composite()
        {
            var div = new LightElementNode("div");
            div.AddClass("container");

            var h1 = new LightElementNode("h1");
            h1.AddChild(new LightTextNode("Welcome to LightHTML"));

            var p = new LightElementNode("p");
            p.AddChild(new LightTextNode("This is a custom markup example."));

            var img = new LightElementNode("img", closing: ClosingType.SelfClosing);
            img.AddClass("responsive");

            div.AddChild(h1);
            div.AddChild(p);
            div.AddChild(img);

            Console.WriteLine("== OuterHTML ==");
            Console.WriteLine(div.OuterHTML);
            Console.WriteLine();
            Console.WriteLine("== InnerHTML ==");
            Console.WriteLine(div.InnerHTML);
        }
    }
}
