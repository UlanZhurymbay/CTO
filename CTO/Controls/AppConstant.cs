using CTO.Views.MainPages.Feed;
using CTO.Views.MainPages.Main;
using CTO.Views.MainPages.Profile;
using CTO.Views.MainPages.Remember;

namespace CTO.Controls
{
    public class AppConstant
    {
        public async static Task AddTabBarDetails()
        {
            if (Shell.Current.FlyoutHeader is null)
            {
                var MainPageInfo = Shell.Current.Items.Where(f => f.Route == nameof(MainPage)).FirstOrDefault();
                if (MainPageInfo != null) Shell.Current.Items.Remove(MainPageInfo);

                var tabBar = new TabBar()
                {
                    Route = nameof(MainPage),
                    Items =
                    {
                        new ShellContent
                        {
                            Icon = "register",
                            Title = "Главная",
                            ContentTemplate = new DataTemplate(typeof(MainPage)),
                        },
                        new ShellContent
                        {
                            Icon = "sale",
                            Title = "Новости",
                            ContentTemplate = new DataTemplate(typeof(FeedPage)),
                        },
                        new ShellContent
                        {
                            Icon = "notify",
                            Title = "Напомнить",
                            ContentTemplate = new DataTemplate(typeof(RememberPage)),
                        },
                        new ShellContent
                        {
                            Icon = "login",
                            Title = "Профиль",
                            ContentTemplate = new DataTemplate(typeof(ProfilePage)),
                        }
                    }
                };

                AppShell.Current.Items.Add(tabBar);
            }
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
