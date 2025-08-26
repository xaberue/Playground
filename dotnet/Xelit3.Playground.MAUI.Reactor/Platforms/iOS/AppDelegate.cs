using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Xelit3.Playground.MAUI.Reactor
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
