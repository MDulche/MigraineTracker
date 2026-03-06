namespace MigraineTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("NewMigraine", typeof(Views.NewMigraine));
    }
}