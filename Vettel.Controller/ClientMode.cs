using System;

namespace Vettel.Controller
{
    internal class ClientMode : IApplicationMode
    {
        private readonly View.View _view;
        private Client.IClient _client;

        public ClientMode()
        {
            _view = new View.View();
        }

        public void Run()
        {
            int port = _view.ReadInputPortNumber();

            _client = new Client.Client(port);
            _client.Listen(message => _view.PrintMessage(message));
            Console.ReadKey();
        }
    }
}
