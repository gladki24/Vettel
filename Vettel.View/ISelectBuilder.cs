using System.Collections.Generic;

namespace Vettel.View
{
    internal interface ISelectBuilder<TValue>
    {
        ISelectBuilder<TValue> Add(string optionKey, TValue value);
        ISelect<TValue> Build();
    }
}
