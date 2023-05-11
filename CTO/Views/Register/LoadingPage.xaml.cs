using CTO.Models;
using CTO.Services.PreferenseSerivces;
using CTO.Views.MainPages.Main;
using CTO.Views.MainPages.Profile;

namespace CTO.Views.Register;

public partial class LoadingPage : ContentPage
{
    private readonly IStorage _storage;
	public LoadingPage(IStorage storage)
	{
        _storage = storage;
		InitializeComponent();
        A();
	}
    private async void A()
	{
        if (_storage.ContainsKey(nameof(User.Email)))
        {
            await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
        }
    }
}