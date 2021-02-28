using System.Runtime.Serialization;

namespace Vettel.Server
{
    public interface IServer<TMessage> where TMessage : ISerializable
    {
        void Send(TMessage message);
    }
}
