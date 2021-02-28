using System.Net;
using Vettel.Server;

namespace Vettel.Controller
{
    internal class ServerMode : IApplicationMode
    {
        private readonly View.View _view;
        private IServer _server;

        public ServerMode()
        {
            _view = new View.View();
        }

        public void Run()
        {
            IPAddress ip = _view.ReadInputIpAddress();
            int port = _view.ReadInputPortNumber();

            _server = new Server.Server(ip, port);

            string message;

            do
            {
                message = _view.ReadMessage();
                _server.Send(message);

            } while (!IsExitInput(message));
        }

        private bool IsExitInput(string message)
        {
            return message == ":bye";
        }
    }
}
