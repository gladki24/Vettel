using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using Vettel.Byte;

namespace Vettel.Server
{
    public class Server<TMessage> : IServer<TMessage> where TMessage : ISerializable
    {
        private readonly IPEndPoint _endPoint;
        private readonly Socket _socket;
        private readonly IBinary<TMessage> _binary;

        public Server(IPAddress ipAddress, int port)
        {
            _endPoint = new IPEndPoint(ipAddress, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _binary = new Binary<TMessage>();
        }

        public void Send(TMessage message)
        {
            byte[] buffer = _binary.Serialize(message);
            _socket.SendTo(buffer, _endPoint);
        }
    }
}
