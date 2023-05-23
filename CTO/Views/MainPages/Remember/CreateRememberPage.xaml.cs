using CTO.Models;
using CTO.Models.Data;
using CTO.Services.PreferenseSerivces;

namespace CTO.Views.MainPages.Remember;

public partial class CreateRememberPage : ContentPage
{
	public static List<string> list = new()
	{
		"Масло с фильтром",
		"ТО",
		"Переобувка",
		"Фильтр кондиционера",
		"Воздушный фильтр двигеателя",
		"Тормозная жидкость",
		"Свечи",
		"Коробка передачи",
		"Колеса",
	};
	private readonly Dictionary<string, string> dic = new() 
	{
		{ list[0],"car_oil" },
		{ list[1],"to" },
		{ list[2],"dongelek" },
		{ list[3],"conder" },
		{ list[4],"conder" },
		{ list[5],"tormoz" },
		{ list[6],"svewi" },
		{ list[7],"corobka" },
		{ list[8],"colesa" },

	};
	private string imageSource = "car_oil";
	private readonly IStorage storage;
	private readonly CTOContext	context;
    public CreateRememberPage(IStorage storage, CTOContext context)
	{
		this.context = context;
		this.storage = storage;
		date = new();
		date.Date = DateTime.Now;
		date.MinimumDate = DateTime.Now;
		InitializeComponent();
	}

    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
			var text = (string)picker.ItemsSource[selectedIndex];
            name.Text = text;
            image.Source = dic[text];
            imageSource = dic[text];
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var notification = new Notification()
		{
			Name = name.Text,
			Mileage = Convert.ToInt32(mileage.Text),
			Icon = imageSource,
			Date = date.Date,
			Description = description.Text,
			UserId = Convert.ToInt32(storage.Get(nameof(User.Id)) ?? "0")
		};
		if (string.IsNullOrEmpty(notification.Name))
		{
			await Shell.Current.DisplayAlert("Ошибка", "Укажите названия", "Ок");
			return;
		}
		if (Convert.ToInt32(mileage.Text ?? "-1") < 0)
		{
            await Shell.Current.DisplayAlert("Ошибка", "Укажите пробег", "Ок");
            return;
        }
		await context.AddAsync(notification);
		await Shell.Current.GoToAsync("..");
    }

    private async void picker_Clicked(object sender, EventArgs e)
    {
        string text = await Shell.Current.DisplayActionSheet("Выберите", "Назад",null, list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8]);
        name.Text = text;
        image.Source = dic[text];
        imageSource = dic[text];
    }
}