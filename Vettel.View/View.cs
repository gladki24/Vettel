using System;
using System.Globalization;
using System.Net;

namespace Vettel.View
{
    public class View
    {
        private readonly IPrinter _printer;
        private readonly IResource _resource;
        private readonly IReader _reader;

        public View()
        {
            _printer = new Printer();
            _resource = new Resource();
            _reader = new Reader();

            SetApplicationTitle();
        }

        public void PrintApplicationInfo()
        {
            _printer.Print(_resource.Get("ApplicationInfo"));
        }

        public void PrintApplicationOptions()
        {
            _printer.Print(_resource.Get("ChooseMode"));
        }

        public ApplicationModeView PrintSelectApplicationMode()
        {
            var selectBuilder = new SelectBuilder<ApplicationModeView>();
            var select = selectBuilder
                .Add("Client", ApplicationModeView.Client)
                .Add("Server", ApplicationModeView.Server)
                .Build();

            return select.Print();
        }

        public void PrintInformationAboutClientMode()
        {
            _printer.Print(_resource.Get("ClientMode"));
        }

        public void PrintInformationAboutServerMode()
        {
            _printer.Print(_resource.Get("ServerMode"));
        }

        public int ReadInputPortNumber()
        {
            _printer.Print(_resource.Get("InputPort"));
            string input;
            int port;

            do 
                input = _reader.Read();
            while (!int.TryParse(input, NumberStyles.AllowTrailingWhite, new NumberFormatInfo(), out port));

            var result = _resource.Get("WorkingPort");
            result += $"{port}";
            _printer.Print(result);

            return port;
        }

        public IPAddress ReadInputIpAddress()
        {
            _printer.Print(_resource.Get("InputIpAddress"));
            string input;
            IPAddress ip;

            do 
                input = _reader.Read();
            while (!IPAddress.TryParse(input, out ip));

            var result = _resource.Get("WorkingIp");
            result += $"{input}";
            _printer.Print(result);

            return ip;
        }

        public string ReadMessage()
        {
            _printer.Print(_resource.Get("MessageToSend"));
            return _reader.Read();
        }

        public void PrintMessage(string message)
        {
            string formatted = _resource.Get("Message");
            formatted += message;
            _printer.Print(formatted);
        }

        private void SetApplicationTitle()
        {
            Console.Title = _resource.Get("Title");
        }
    }
}
