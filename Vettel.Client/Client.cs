using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Vettel.Client
{
    public class Client : IClient
    {
        private readonly UdpClient _listener;
        
        public Client(int port)
        {
            _listener = new UdpClient(port);
        }

        public void Listen(Action<string> callback)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = _listener.Receive(ref endPoint);
                string message = Encoding.UTF8.GetString(bytes);

                if (IsCloseMessage(message))
                    break;

                callback(message);
            }
        }

        private bool IsCloseMessage(string message)
        {
            return message == ":bye";
        }
    }
}
