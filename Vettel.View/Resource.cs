using System.Resources;

namespace Vettel.View
{
    internal class Resource : IResource
    {
        private readonly ResourceManager _resourceManager;

        public Resource()
        {
            _resourceManager = Messages.ResourceManager;
        }

        public string Get(string key)
        {
            return _resourceManager.GetString(key);
        }
    }
}
