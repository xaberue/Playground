namespace Xelit3.Playground.MAUI.Pages;

public partial class TodoList : ContentPage
{
	public TodoList(TodoListViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
	}
}