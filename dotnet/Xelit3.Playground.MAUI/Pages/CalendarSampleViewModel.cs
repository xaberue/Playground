using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Calendar.Models;
using Xelit3.Playground.MAUI.Models;

namespace Xelit3.Playground.MAUI.Pages;

public partial class CalendarSampleViewModel : ObservableObject
{

    [ObservableProperty]
    private EventCollection events = new EventCollection();


    [RelayCommand]
    private void OnLoad()
    {
        Events = new EventCollection
        {
            [DateTime.Now.AddDays(5)] = new List<EventModel>
            {
                new("Cool event 1", "This is Cool event 1's description!"),
                new("Cool event 2", "This is Cool event 2's description!"),
            },                    
            [DateTime.Now.AddDays(7)] = new List<EventModel>
            {
                new("Cool event 3", "This is Cool event 3's description!")
            },
            [DateTime.Now.AddDays(-3)] = new List<EventModel>
            {
                new("Cool PAST event", "This is Cool past event's description!")
            }
        };
    }

}
