using System;

namespace Vettel.View
{
    internal class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKeyInfo()
        {
            return Console.ReadKey();
        }
    }
}
