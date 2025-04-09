using System;
using System.Text.RegularExpressions;

namespace Templates.Proxy
{
    public class SmartTextReaderLocker : ITextReader
    {
        private readonly ITextReader _realReader;
        private readonly Regex _denyPattern;

        public SmartTextReaderLocker(ITextReader realReader, string denyPattern)
        {
            _realReader = realReader;
            _denyPattern = new Regex(denyPattern, RegexOptions.IgnoreCase);
        }

        public char[][] ReadText(string filePath)
        {
            if (_denyPattern.IsMatch(filePath))
            {
                Console.WriteLine("Access denied!");
                return Array.Empty<char[]>();
            }

            return _realReader.ReadText(filePath);
        }
    }
}
