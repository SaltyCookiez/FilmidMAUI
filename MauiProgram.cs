using CommunityToolkit.Maui;
using FilmidMAUI.Services;
using Microsoft.Extensions.Logging;

namespace FilmidMAUI;

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
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName,
			HttpClient => HttpClient.BaseAddress = new Uri("https://api.themoviedb.org"));

		return builder.Build();
	}
}
