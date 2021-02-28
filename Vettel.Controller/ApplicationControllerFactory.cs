using Vettel.View;

namespace Vettel.Controller
{
    internal class ApplicationControllerFactory : IApplicationControllerFactory
    {
        public IApplicationController Create(ApplicationModeView input)
        {
            switch (input)
            {
                case ApplicationModeView.Client:
                    return new ClientController();
                case ApplicationModeView.Server:
                    return new ServerController();
                default:
                    throw new InvalidApplicationModeException();
            }
        }
    }
}
