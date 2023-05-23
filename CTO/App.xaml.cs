using CTO.Models;

namespace CTO;

public partial class App : Application
{
    public static List<Notification> List = new();
    public App()
	{
		Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
		MainPage = new AppShell();
	}
}
