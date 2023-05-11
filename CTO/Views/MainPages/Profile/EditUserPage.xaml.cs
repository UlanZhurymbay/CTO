using CTO.Models;
using CTO.Services.AuthServices;
using CTO.Services.PreferenseSerivces;
using CTO.Services.ValidationServices;

namespace CTO.Views.MainPages.Profile;

public partial class EditUserPage : ContentPage
{
	private readonly IValidation _validation;
	private readonly IAuth _auth;
	private readonly IStorage _storage;
	public EditUserPage(IValidation validation, IAuth auth, IStorage storage)
	{
		_storage = storage;
		_auth = auth;
		_validation = validation;
		InitializeComponent();
		InitUser();
	}

    private void InitUser()
    {
        Name.Text = _storage.Get(nameof(User.Name));
        PhoneNumber.Text = _storage.Get(nameof(User.PhoneNumber));
        Email.Text = _storage.Get(nameof(User.Email));
    }
    private async void Edit_Clicked(object sender, EventArgs e)
    {
		var user = new User()
		{
			Name = this.Name.Text,
			Email = this.Email.Text,
			PhoneNumber = this.PhoneNumber.Text,
		};
		if (_validation.CheckUserWithoutPassword(user))
		{
			if (await _auth.EditAsync(user, _storage.Get(nameof(User.Email))))
			{
				await Shell.Current.GoToAsync("..");
			}
		}
    }
	private async void Back_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}