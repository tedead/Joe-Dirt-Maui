using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Plugin.Maui.Audio;

namespace MauiApp1;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton(AudioManager.Current);

        builder.ConfigureMauiHandlers(h => h.AddHandler<NamedEntry, EntryHandler>());

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}