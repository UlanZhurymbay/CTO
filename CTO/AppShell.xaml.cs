using CTO.Views.MainPages.Main;
using CTO.Views.MainPages.Profile;
using CTO.Views.Register;

namespace CTO;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        #region Routing
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(EditUserPage), typeof(EditUserPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        //TablePages
        Routing.RegisterRoute(nameof(TablePage1), typeof(TablePage1));
        #endregion
    }
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        if (args.Source == ShellNavigationSource.ShellSectionChanged)
        {
            var navigation = Shell.Current.Navigation;
            var pages = navigation.NavigationStack;
            for (var i = pages.Count - 1; i >= 1; i--)
            {
                navigation.RemovePage(pages[i]);
            }
        }
    }
}
