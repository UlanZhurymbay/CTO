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
    private async void Table2_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage2));
    }
    private async void Table3_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage3));
    }
    private async void Table4_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage4));
    }
    private async void Table5_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage5));
    }
    private async void Table6_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(TablePage6));
    }
}

