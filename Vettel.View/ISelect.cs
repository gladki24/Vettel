using System.Threading.Tasks;

namespace Vettel.View
{
    internal interface ISelect<TValue>
    {
        TValue Print();
    }
}
