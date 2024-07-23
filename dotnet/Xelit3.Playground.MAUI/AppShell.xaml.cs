using Xelit3.Playground.MAUI.Pages;

namespace Xelit3.Playground.MAUI;


public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(TodoList), typeof(TodoList));
        Routing.RegisterRoute(nameof(TodoDetail), typeof(TodoDetail));
        Routing.RegisterRoute(nameof(CalendarSample), typeof(CalendarSample));
    }
}
