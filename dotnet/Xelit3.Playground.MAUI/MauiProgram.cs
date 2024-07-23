using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Xelit3.Playground.MAUI.Pages;

namespace Xelit3.Playground.MAUI;


public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton(Connectivity.Current);

        builder.Services.AddSingleton<TodoList>();
        builder.Services.AddSingleton<TodoListViewModel>();

        builder.Services.AddTransient<TodoDetail>();
        builder.Services.AddTransient<TodoDetailViewModel>();

        builder.Services.AddTransient<CalendarSample>();
        builder.Services.AddTransient<CalendarSampleViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
