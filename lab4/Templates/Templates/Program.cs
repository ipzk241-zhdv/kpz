using System;
using System.IO;
using Templates.Composite;

namespace Templates
{
    class Program
    {
        static void Main()
        {
            Strategy();
        }

        static void Strategy()
        {
            var localImg = new LightImageNode("assets/picture.png");
            Console.WriteLine("== Local Image HTML ==");
            Console.WriteLine(localImg.OuterHTML);
            localImg.LoadImage();

            Console.WriteLine();

            var remoteImg = new LightImageNode("https://example.com/photo.jpg");
            Console.WriteLine("== Remote Image HTML ==");
            Console.WriteLine(remoteImg.OuterHTML);
            remoteImg.LoadImage();
        }
    }
}
