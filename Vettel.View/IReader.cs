using System;

namespace Vettel.View
{
    internal interface IReader
    {
        string Read();
        ConsoleKeyInfo ReadKeyInfo();
    }
}
