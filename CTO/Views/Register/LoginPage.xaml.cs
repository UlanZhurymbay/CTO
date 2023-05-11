using CommunityToolkit.Maui.Alerts;
using CTO.Services.AuthServices;
using CTO.Services.ValidationServices;
using CTO.Views.MainPages.Main;

namespace CTO.Views.Register;

public partial class LoginPage : ContentPage
{
	private readonly IAuth _auth;
	private readonly IValidation _validation;
	public LoginPage(IAuth auth, IValidation validation)
	{
		_validation = validation;
		_auth = auth;
		InitializeComponent();
	}

    private async void Register_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(RegisterPage));
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
		if (_validation.CheckEmailAndPassword(Email.Text, Password.Text))
        {
            if (await _auth.LoginAsync(Email.Text, Password.Text))
            {
                await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
            else
            {
                await Snackbar.Make("Неверное данные").Show();
            }
        }

    }
}