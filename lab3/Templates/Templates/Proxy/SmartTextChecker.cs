using System;

namespace Templates.Proxy
{
    public class SmartTextChecker : ITextReader
    {
        private readonly ITextReader _realReader;

        public SmartTextChecker(ITextReader realReader)
        {
            _realReader = realReader;
        }

        public char[][] ReadText(string filePath)
        {
            Console.WriteLine($"[INFO] Opening file: {filePath}");

            var result = _realReader.ReadText(filePath);

            Console.WriteLine($"[INFO] Successfully read file: {filePath}");
            Console.WriteLine($"[INFO] Closing file: {filePath}");

            int lineCount = result.Length;
            int charCount = 0;

            foreach (var line in result)
            {
                charCount += line.Length;
            }

            Console.WriteLine($"[INFO] Total lines: {lineCount}");
            Console.WriteLine($"[INFO] Total characters: {charCount}");

            return result;
        }
    }

}
