using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Xelit3.Playground.MAUI.Pages;

[QueryProperty("Text", "Text")]
public partial class TodoDetailViewModel : ObservableObject
{

    [ObservableProperty]
    string text = string.Empty;

    [RelayCommand]
    async Task OnBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
