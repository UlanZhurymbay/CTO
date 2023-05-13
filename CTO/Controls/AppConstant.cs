using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTO.Views.MainPages.Main;
using CTO.Views.MainPages.Profile;
using Microsoft.Maui.Controls;

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
