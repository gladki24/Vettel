using System;
using System.Text;

namespace Vettel.View
{
    internal class Printer : IPrinter
    {
        public void Print(string message)
        {
            Console.Out.WriteLine(message);
        }

        public void Print(StringBuilder message)
        {
            Console.Out.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
