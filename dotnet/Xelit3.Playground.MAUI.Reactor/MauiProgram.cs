using Xelit3.Playground.MAUI.Reactor.Components;
using Xelit3.Playground.MAUI.Reactor.Resources.Styles;

namespace Xelit3.Playground.MAUI.Reactor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiReactorApp<HomePage>(app =>
            {
                app.UseTheme<ApplicationTheme>();
            },
            unhandledExceptionAction: e =>
            {
                System.Diagnostics.Debug.WriteLine(e.ExceptionObject);
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        return builder.Build();
    }
}
