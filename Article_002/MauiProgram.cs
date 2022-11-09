#if ANDROID
using Article_002.Platforms.Android.Renderes;
#elif IOS
using Article_002.Platforms.iOS.Renderes;
#endif

namespace Article_002;

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

#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.PlatformViewFactory =
        handler => new EntryImage();
#elif IOS
Microsoft.Maui.Handlers.EntryHandler.PlatformViewFactory =
        handler => new EntryImage();
#endif

        //                    .ConfigureMauiHandlers((handlers) => {
        //#if ANDROID
        //                        handlers.AddHandler(typeof(ImageEntry), typeof(Platforms.Android.Renderes.ImageEntryRenderer));

        //#elif IOS                    
        //                        handlers.AddHandler(typeof(ImageEntry), typeof(Platforms.iOS.Renderes.ImageEntryRenderer));
        //#endif
        //                    });

        return builder.Build();
	}
}
