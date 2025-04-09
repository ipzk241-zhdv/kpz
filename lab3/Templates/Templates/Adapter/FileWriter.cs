﻿using System;
using System.IO;

namespace Templates.Adapter
{
    public class FileWriter
    {
        private readonly string filePath;

        public FileWriter(string path)
        {
            filePath = path;
        }

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
