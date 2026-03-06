using Microsoft.Maui.Controls;
using MigraineTracker.ViewModels;

namespace MigraineTracker.Views;

public partial class NewMigraine : ContentPage
{
    public NewMigraine(NewMigraineViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

    }
}
