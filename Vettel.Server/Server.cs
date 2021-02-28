using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Vettel.Server
{
    public class Server
    {
        private IPEndPoint endPoint { get; }
        private Socket socket { get; }

        public Server(IPAddress ipAddress, int port)
        {
            endPoint = new IPEndPoint(ipAddress, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Send(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            socket.SendTo(buffer, endPoint);
        }
    }
}
