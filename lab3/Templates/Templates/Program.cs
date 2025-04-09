using System;
using System.IO;
using Templates.Adapter;

namespace Templates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new Logger();
            consoleLogger.Log("=== Console Logger ===");
            consoleLogger.Log("Everything is running smoothly.");
            consoleLogger.Warn("This might be an issue.");
            consoleLogger.Error("Something went wrong!");

            Console.WriteLine("\n=== File Logger via Adapter ===");
            string currentPath = Directory.GetCurrentDirectory();
            string path = currentPath + "/adapterLog.txt";
            FileWriter writer = new FileWriter(path);
            IWriterLogger fileLogger = new FileLoggerAdapter(writer);

            fileLogger.Log("File log successful.");
            fileLogger.Warn("File warning message.");
            fileLogger.Error("File error message.");

            Console.WriteLine($"Logs written to file: {path}");
            consoleLogger.Log("=== Console Logger End ===");
            Console.ReadKey();
        }
    }
}
