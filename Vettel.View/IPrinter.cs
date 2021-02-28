using System.Text;

namespace Vettel.View
{
    internal interface IPrinter
    {
        void Print(string message);
        void Print(StringBuilder message);
        void Clear();
    }
}
