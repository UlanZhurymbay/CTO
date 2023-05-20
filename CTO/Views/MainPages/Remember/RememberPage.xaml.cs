using CTO.Models;
using CTO.Models.Data;
using CTO.Services.PreferenseSerivces;
using System.Collections.Generic;

namespace CTO.Views.MainPages.Remember;

public partial class RememberPage : ContentPage
{
    private bool isVisibleList;
    private readonly CTOContext context;
    private readonly IStorage storage;
    private readonly int userId = Convert.ToInt32(Preferences.Get(nameof(User.Id), "0") ?? "0");
    public RememberPage(CTOContext context, IStorage storage)
	{
        this.storage = storage;
        this.context = context;
		InitializeComponent();
	}
    
    protected override async void OnAppearing()
    {
        ListView.ItemsSource = await context.GetAllAsync<Notification>(n => n.UserId == userId) ?? new();
        base.OnAppearing();
    }
    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var notificationId = (int)button.CommandParameter;
        var notification = await context.GetAsync<Notification>(n => n.Id == notificationId);
        await context.DeleteAsync(notification);
        ListView.ItemsSource = await context.GetAllAsync<Notification>(n => n.UserId == userId);
    }
    private async void Create_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CreateRememberPage));
    }

}