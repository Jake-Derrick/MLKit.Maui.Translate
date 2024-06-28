using Microsoft.Extensions.Logging;
using MLKit.Maui.Translate;

namespace Example.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .RegisterViewModelsAndViews();

        builder.Services.AddTranslationService();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterViewModelsAndViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<TranslationExampleViewModel>();
        builder.Services.AddSingleton<TranslationExampleView>();

        return builder;
    }
}
