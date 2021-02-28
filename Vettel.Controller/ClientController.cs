using System;
using Vettel.Model;

namespace Vettel.Controller
{
    internal class ClientController : IApplicationController
    {
        private readonly View.View _view;
        private Client.IClient<User> _client;

        public ClientController()
        {
            _view = new View.View();
        }

        public void Run()
        {
            int port = _view.ReadInputPortNumber();

            _client = new Client.Client<User>(port);
            _client.Listen(message => _view.PrintMessage(message.ToString()));
            Console.ReadKey();
        }
    }
}
