using System.IO;

namespace Templates.Proxy
{
    public class SmartTextReader : ITextReader
    {
        public char[][] ReadText(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
    }

}
