using MauiApp2.page;

namespace MauiApp2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
		// Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
		Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage));
		Routing.RegisterRoute(nameof(RegistrationPage),typeof(RegistrationPage));
		Routing.RegisterRoute(nameof(RegistrationView),typeof(RegistrationView));
		Routing.RegisterRoute(nameof(RegisterInformation),typeof(RegisterInformation));
	}
}
