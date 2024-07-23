namespace Xelit3.Playground.MAUI.Pages;

public partial class CalendarSample : ContentPage
{
	public CalendarSample(CalendarSampleViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}