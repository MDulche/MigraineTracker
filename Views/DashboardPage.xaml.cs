using MigraineTracker.ViewModels;

namespace MigraineTracker.Views;

public partial class DashboardPage : ContentPage
{
    private DashboardViewModel _viewModel;

    public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = viewModel;
		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.LoadData();
    }
}