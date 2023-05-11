using CTO.Models;
using CTO.Models.Data;

namespace CTO.Views.MainPages.Main;

public partial class MainPage : ContentPage
{
	private readonly CTOContext _context;

	public MainPage(CTOContext context)
	{
		_context = context;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
		Uuu.Text = string.Empty;
        var users = await _context.GetAllAsync<User>();
		foreach (var user in users)
		{
			Uuu.Text += user.Name + " ";
		}
        base.OnAppearing();
    }
}

