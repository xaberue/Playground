namespace Xelit3.Playground.MAUI.Pages;

public partial class TodoDetail : ContentPage
{
	public TodoDetail(TodoDetailViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
	}
}