using MauiApp2.page;

namespace MauiApp2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
		Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
	}
}
