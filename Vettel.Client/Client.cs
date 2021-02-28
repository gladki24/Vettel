using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using Vettel.Byte;

namespace Vettel.Client
{
    public class Client<T> : IClient<T> where T : ISerializable
    {
        private readonly UdpClient _listener;
        private readonly Binary<T> _binary;
        
        public Client(int port)
        {
            _listener = new UdpClient(port);
            _binary = new Binary<T>();
        }

        public void Listen(Action<T> callback)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = _listener.Receive(ref endPoint);
                T message = _binary.Deserialize(bytes);

                callback(message);
            }
        }

        private bool IsCloseMessage(string message)
        {
            return message == ":bye";
        }
    }
}
