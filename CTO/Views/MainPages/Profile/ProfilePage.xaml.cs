using CTO.Models;
using CTO.Services.PreferenseSerivces;

namespace CTO.Views.MainPages.Profile;

public partial class ProfilePage : ContentPage
{
	private readonly IStorage _storage;
	public ProfilePage(IStorage storage)
	{
		_storage = storage;
		InitializeComponent();
	}
	private void InitUser()
	{
		Name.Text = $"Привет {_storage.Get(nameof(User.Name))}";
		PhoneNumber.Text = _storage.Get(nameof(User.PhoneNumber));
		Email.Text = _storage.Get(nameof(User.Email));
	}
    protected override void OnAppearing()
    {
        InitUser();
        base.OnAppearing();
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(EditUserPage));
    }
}