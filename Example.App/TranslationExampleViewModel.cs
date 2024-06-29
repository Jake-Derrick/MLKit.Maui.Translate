using CommunityToolkit.Mvvm.ComponentModel;
using MLKit.Maui.Translate;
using System.ComponentModel;

namespace Example.App;

public partial class TranslationExampleViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly ITranslationService _translationService;
    private List<Language> _downloadedLanguages = [];

    public TranslationExampleViewModel(ITranslationService translationService)
    {
        _translationService = translationService;
    }

    [ObservableProperty]
    private Language? _selectedSourceLanguage = Languages.English;

    [ObservableProperty]
    private Language? _selectedTargetLanguage;

    [ObservableProperty]
    private string? _inputText;

    [ObservableProperty]
    private string? _translatedText;

    [ObservableProperty]
    private static List<Language> _availableLanguages = Languages.AllLanguages;

    [ObservableProperty]
    private string? _errorMessage;

    async partial void OnInputTextChanged(string? value) => await TranslateInputText();
    async partial void OnSelectedSourceLanguageChanged(Language? value) => await TranslateInputText();
    async partial void OnSelectedTargetLanguageChanged(Language? value) => await TranslateInputText();

    private async Task TranslateInputText()
    {
        ErrorMessage = null;
        if (SelectedSourceLanguage is null || SelectedTargetLanguage is null || string.IsNullOrWhiteSpace(InputText))
            return;

        var sourceDownloaded = await DownloadLanguageModelIfNeeded(SelectedSourceLanguage);
        var targetDownloaded = await DownloadLanguageModelIfNeeded(SelectedTargetLanguage);

        if (!sourceDownloaded || !targetDownloaded)
            return;

        var translationResult = await _translationService.Translate(InputText, SelectedSourceLanguage, SelectedTargetLanguage);
        if (!translationResult.IsSuccess)
        {
            ErrorMessage = translationResult.ErrorMessage;
            return;
        }

        TranslatedText = translationResult.TranslatedText;
    }

    private async Task<bool> DownloadLanguageModelIfNeeded(Language language)
    {
        if (_downloadedLanguages.Contains(language))
            return true;

        if (!IsWifiEnabled())
        {
            // Could have a popup asking if they want to download without Wi-Fi and set DownloadOptions with RequireWifi as false
            // But I'm lazy so just returning an error
            ErrorMessage = "Please turn on Wi-Fi to download language models.";
            return false;
        }

        var result = await _translationService.DownloadLanguageModel(language, DownloadOptions.Default);
        if (!result.IsSuccess)
            ErrorMessage = result.ErrorMessage;

        return result.IsSuccess;
    }

    internal async void OnAppearing()
    {
        _downloadedLanguages = await _translationService.GetDownloadedLanguageModels();
    }

    private bool IsWifiEnabled()
    {
#if ANDROID
        var wifiManager = (Android.Net.Wifi.WifiManager?)Android.App.Application.Context.GetSystemService(Android.Content.Context.WifiService);
        return wifiManager?.IsWifiEnabled ?? false;
#endif
        return false;
    }
}
