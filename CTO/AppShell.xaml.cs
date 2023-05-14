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
        Routing.RegisterRoute(nameof(TablePage2), typeof(TablePage2));
        Routing.RegisterRoute(nameof(TablePage3), typeof(TablePage3));
        Routing.RegisterRoute(nameof(TablePage4), typeof(TablePage4));
        Routing.RegisterRoute(nameof(TablePage5), typeof(TablePage5));
        Routing.RegisterRoute(nameof(TablePage6), typeof(TablePage6));
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
