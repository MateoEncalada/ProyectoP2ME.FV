namespace ProyectoP2ME.FV;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = FileAccessHelper.GetLocalFilePath("InformacionME_FV.db3");
		builder.Services.AddSingleton<InfoRepository>(s => ActivatorUtilities.CreateInstance<InfoRepository>(s, dbPath));

        return builder.Build();
	}
}
