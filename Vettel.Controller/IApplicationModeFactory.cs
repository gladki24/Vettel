using Vettel.View;

namespace Vettel.Controller
{
    internal interface IApplicationModeFactory
    {
        IApplicationMode Create(ApplicationModeView input);
    }
}
