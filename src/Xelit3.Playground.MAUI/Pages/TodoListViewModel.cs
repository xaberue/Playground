using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Xelit3.Playground.MAUI.Pages;


public partial class TodoListViewModel : ObservableObject
{

    public TodoListViewModel()
    {
        text = string.Empty;
        items = new ObservableCollection<string>();
    }


    [ObservableProperty]
    string text;

    [ObservableProperty]
    ObservableCollection<string> items;

    [RelayCommand]
    void OnAdd()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void OnDelete(string itemStr)
    {
        if(Items.Contains(itemStr))
            Items.Remove(itemStr);
    }
}
