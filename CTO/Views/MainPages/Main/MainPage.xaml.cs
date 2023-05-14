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

    private async void Table1_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage1));
    }
}

