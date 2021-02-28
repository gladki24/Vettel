using System;

namespace Vettel.Controller
{
    internal class InvalidApplicationModeException : Exception
    {
        public InvalidApplicationModeException() : base("Application is in unsupported mode")
        { }
    }
}
