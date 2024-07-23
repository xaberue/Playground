using Xelit3.Playground.MAUI.Pages;

namespace Xelit3.Playground.MAUI;


public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void OnToDoNavigationClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(TodoList));
    }

    private void OnCalendarNavigationClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CalendarSample));
    }
}
