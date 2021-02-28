using Vettel.View;

namespace Vettel.Controller
{
    internal interface IApplicationControllerFactory
    {
        IApplicationController Create(ApplicationModeView input);
    }
}
