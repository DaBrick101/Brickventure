using Brickventure_Library_0._1;
using System;

namespace Brickventure_ConsoleApp
{
    public class ConsoleOutputMessageWriter : IOutputMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
        }

        public string GetMessage()
        {
            return string.Empty;
        }
    }
}
