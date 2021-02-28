using System.Collections.Generic;

namespace Vettel.View
{
    internal class SelectBuilder<TValue> : ISelectBuilder<TValue>
    {
        private readonly IList<KeyValuePair<string, TValue>> _options;
        private readonly IResource _resource;

        public SelectBuilder()
        {
            _options = new List<KeyValuePair<string, TValue>>();
            _resource = new Resource();
        }

        public ISelectBuilder<TValue> Add(string optionKey, TValue value)
        {
            var option = new KeyValuePair<string, TValue>(optionKey, value);
            _options.Add(option);
            return this;
        }

        public ISelect<TValue> Build()
        {
            var options = new List<KeyValuePair<string, TValue>>();
            foreach (var pair in _options)
            {
                var option = new KeyValuePair<string, TValue>(_resource.Get(pair.Key), pair.Value);
                options.Add(option);
            }

            return new Select<TValue>(options);
        }
    }
}
