using CommunityToolkit.Maui;
using CTO.Models.Data;
using CTO.Services.AuthServices;
using CTO.Services.PasswordServices;
using CTO.Services.PreferenseSerivces;
using CTO.Services.SnackbarServices;
using CTO.Services.ValidationServices;
using CTO.Views.MainPages.Feed;
using CTO.Views.MainPages.Main;
using CTO.Views.MainPages.Profile;
using CTO.Views.MainPages.Remember;
using CTO.Views.Register;
using Microsoft.Extensions.Logging;

namespace CTO;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //context
        builder.Services.AddSingleton<CTOContext>();

        //service
        builder.Services.AddTransient<IValidation, ValidationService>();
        builder.Services.AddTransient<IPassword, PasswordService>();
        builder.Services.AddTransient<ISnackbar, SnackbarService>();
		builder.Services.AddTransient<IStorage, AppStorage>();
		builder.Services.AddTransient<IAuth, AuthService>();

		//views
        builder.Services.AddTransient<CreateRememberPage>();
        builder.Services.AddTransient<RememberPage>();
        builder.Services.AddTransient<FeedPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<EditUserPage>();
        //tablepages
        builder.Services.AddTransient<TablePage1>();
        builder.Services.AddTransient<TablePage2>();
        builder.Services.AddTransient<TablePage3>();
        builder.Services.AddTransient<TablePage4>();
        builder.Services.AddTransient<TablePage5>();
        builder.Services.AddTransient<TablePage6>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
