using Microsoft.Extensions.Logging;

namespace ElementosQuimicos
{
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
                    fonts.AddFont("comic.ttf", "comic");
                    fonts.AddFont("comicbd.ttf", "comicbd");
                    fonts.AddFont("comici.ttf", "comici");
                    fonts.AddFont("comicz.ttf", "comicz");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
