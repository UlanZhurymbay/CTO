using CommunityToolkit.Maui.Alerts;
using CTO.Models;
using CTO.Models.Data;
using CTO.Services.AuthServices;
using CTO.Services.ValidationServices;
using CTO.Views.MainPages.Main;

namespace CTO.Views.Register;

public partial class RegisterPage : ContentPage
{
    private readonly IAuth _auth;
    private readonly IValidation _validation;

    public RegisterPage(IAuth auth, IValidation validation)
	{
        _validation = validation;
        _auth = auth;
        InitializeComponent();
	}

    private async void Back_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }

    private async void Register_Clicked(object sender, EventArgs e)
    {
        var user = new User()
        {
            Name = this.Name.Text,
            Email = this.Email.Text,
            PhoneNumber = this.PhoneNumber.Text,
            Password = this.Password.Text,
        };
        if (_validation.CheckUser(user))
        {
            if (await _auth.RegisterAsync(user))
            {
                await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
            else
            {
                Snackbar.Make("Неверное заполнение");
            }
        }


    }
}