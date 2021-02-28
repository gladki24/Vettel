using System;
using System.Runtime.Serialization;

namespace Vettel.Client
{
    public interface IClient<T> where T : ISerializable
    {
        void Listen(Action<T> callback);
    }
}
