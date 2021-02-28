using Vettel.View;

namespace Vettel.Controller
{
    internal class ApplicationModeFactory : IApplicationModeFactory
    {
        public IApplicationMode Create(ApplicationModeView input)
        {
            switch (input)
            {
                case ApplicationModeView.Client:
                    return new ClientMode();
                case ApplicationModeView.Server:
                    return new ServerMode();
                default:
                    throw new InvalidApplicationModeException();
            }
        }
    }
}
