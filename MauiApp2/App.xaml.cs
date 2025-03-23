using MauiApp2.page;

namespace MauiApp2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// return new Window(new AppShell());
		// return new Window(new HomePage());
		return new Window(new AppShell());
	}
}