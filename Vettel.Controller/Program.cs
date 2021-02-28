using Vettel.View;

namespace Vettel.Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            View.View view = new View.View();
            view.PrintApplicationInfo();
            view.PrintApplicationOptions();

            var applicationModeView = view.PrintSelectApplicationMode();

            if (applicationModeView == ApplicationModeView.Client)
                view.PrintInformationAboutClientMode();

            if (applicationModeView == ApplicationModeView.Server)
                view.PrintInformationAboutServerMode();

            IApplicationControllerFactory applicationControllerFactory = new ApplicationControllerFactory();
            IApplicationController applicationController = applicationControllerFactory.Create(applicationModeView);

            applicationController.Run();
        }
    }
}
