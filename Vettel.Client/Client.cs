using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Vettel.Client
{
    public class Client : IClient
    {
        private UdpClient _listener;
        
        public Client(int port)
        {
            _listener = new UdpClient(port);
        }

        public string Listen()
        {
            var message = _listener.ReceiveAsync();
            using (message)
            {
                return Encoding.UTF8.GetString(message.Result.Buffer);
            }
        }
    }
}
