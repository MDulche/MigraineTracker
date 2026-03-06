using MigraineTracker.ViewModels;

namespace MigraineTracker.Views;

public partial class HistoryPage : ContentPage
{
    private HistoryViewModel _viewModel;
	public HistoryPage(HistoryViewModel viewModel)
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