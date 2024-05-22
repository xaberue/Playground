using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Xelit3.Playground.MAUI.Pages;


public partial class TodoListViewModel : ObservableObject
{

    private readonly IConnectivity _connectivity;


    public TodoListViewModel(IConnectivity connectivity)
    {
        _connectivity = connectivity;

        text = string.Empty;
        items = new ObservableCollection<string>();
    }


    [ObservableProperty]
    string text;

    [ObservableProperty]
    ObservableCollection<string> items;

    [RelayCommand]
    async Task OnAdd()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh oh!", "No internet access currently", "OK");
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void OnDelete(string itemStr)
    {
        if(Items.Contains(itemStr))
            Items.Remove(itemStr);
    }

    [RelayCommand]
    async Task OnTap(string itemStr)
    {
        //Simple navigation
        //await Shell.Current.GoToAsync(nameof(TodoDetail));

        await Shell.Current.GoToAsync($"{nameof(TodoDetail)}?Text={itemStr}");
    }
}
