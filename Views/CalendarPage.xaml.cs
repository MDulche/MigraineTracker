namespace MigraineTracker.Views;

public partial class CalendarPage : ContentPage
{
    public CalendarPage(ViewModels.CalendarViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((ViewModels.CalendarViewModel)BindingContext).LoadData();
    }
}
