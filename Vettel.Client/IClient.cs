using System;

namespace Vettel.Client
{
    public interface IClient
    {
        void Listen(Action<string> callback);
    }
}
