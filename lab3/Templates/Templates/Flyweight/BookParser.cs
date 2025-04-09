using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Templates.Composite;

namespace Templates.Flyweight
{
    public static class BookParser
    {
        public static LightElementNode ParseBookToHtml(string filePath, out long memorySize)
        {
            var factory = new LightElementFlyweightFactory();
            var root = new LightElementNode("div");
            var lines = File.ReadAllLines(filePath);
            var elements = new List<LightElementNode>();

            foreach (var line in lines)
            {
                var trimmed = line.TrimEnd();

                if (string.IsNullOrWhiteSpace(trimmed)) continue;

                string tag = DetermineTag(trimmed);
                var template = factory.GetElement(tag);

                // Копіюємо лише структуру, не сам flyweight-об'єкт
                var instance = new LightElementNode(tag);
                instance.AddChild(new LightTextNode(trimmed.Trim()));
                root.AddChild(instance);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            memorySize = GC.GetTotalMemory(true);

            return root;
        }

        private static string DetermineTag(string line)
        {
            if (line.Length < 20)
                return "h2";
            if (char.IsWhiteSpace(line[0]))
                return "blockquote";
            if (line == File.ReadLines(BookPath).First())
                return "h1";
            return "p";
        }

        public static string BookPath => Path.Combine(Directory.GetCurrentDirectory(), "book.txt");
    }
}
