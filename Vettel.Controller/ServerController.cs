using System.Net;
using Vettel.Model;
using Vettel.Server;

namespace Vettel.Controller
{
    internal class ServerController : IApplicationController
    {
        private readonly View.View _view;
        private IServer<User> _server;

        public ServerController()
        {
            _view = new View.View();
        }

        public void Run()
        {
            IPAddress ip = _view.ReadInputIpAddress();
            int port = _view.ReadInputPortNumber();

            _server = new Server.Server<User>(ip, port);

            string message;

            do
            {
                message = _view.ReadMessage();

                User user = new User();

                user.Name = message;
                user.Surname = "Vettel";

                _server.Send(user);

            } while (!IsExitInput(message));
        }

        private bool IsExitInput(string message)
        {
            return message == ":bye";
        }
    }
}
