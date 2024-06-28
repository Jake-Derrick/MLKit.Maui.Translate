namespace MLKit.Maui.Translate;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the TranslationService to the service collection as a singleton.
    /// </summary>
    public static IServiceCollection AddTranslationService(this IServiceCollection services)
    {
        services.AddSingleton<ITranslationService, TranslationService>();
        return services;
    }
}