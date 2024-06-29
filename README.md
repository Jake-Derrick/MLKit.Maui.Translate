# MLKit.Maui.Translate
Provides easier access to Google [ML Kits Translation API](https://developers.google.com/ml-kit/language/translation) for .NET MAUI.

![TranslationExample](https://github.com/Jake-Derrick/MLKit.Maui.Translate/assets/60721064/ef62b316-772f-451a-9226-afd1d3827f8e)

## How to use it?
1. Install the [NuGet package](https://www.nuget.org/packages/MLKit.Maui.Translate/)
```
Install-Package MLKit.Maui.Translate
```
2. Initialize the Translation Service in `MauiProgram.cs`.
```csharp
var builder = MauiApp.CreateBuilder()
    .UseMauiApp<App>()

builder.Services.AddTranslationService();
```
3. Use the service to download language models and translate text.
```csharp
private readonly ITranslationService _translationService;

public TranslationExampleViewModel(ITranslationService translationService)
{
    _translationService = translationService;
}

public async Task DownloadModel()
{
    // The language models need to be downloaded before calling Translate
    DownloadResult result = await _translationService.DownloadLanguageModel(Languages.Spanish, DownloadOptions.Default);
}

public async Task TranslateText()
{
    TranslationResult translationResult = await _translationService.Translate("The text to translate", sourceLanguage: Languages.English, targetLanguage: Languages.Spanish);
    string translatedText = translationResult.TranslatedText;
}
```
4. Deleting Language Models
```csharp
public async Task DeleteModel()
{
    List<Language> downloadedLanguages = await _translationService.GetDownloadedLanguageModels();

    if (downloadedLanguages.Contains(Languages.Spanish))
      DeleteResult deleteResult = await _translationService.DeleteLanguageModel(Languages.Spanish);
}
```

## More Info
* [Supported Languages](https://github.com/Jake-Derrick/MLKit.Maui.Translate/blob/main/MLKit.Maui.Translate/Models/Languages.cs)
* [MLKit on-device translation guidelines](https://developers.google.com/ml-kit/language/translation/translation-terms)
