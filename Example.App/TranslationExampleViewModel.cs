using CommunityToolkit.Mvvm.ComponentModel;
using MLKit.Maui.Translate;
using System.ComponentModel;

namespace Example.App;

public partial class TranslationExampleViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly ITranslationService _translationService;

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

    async partial void OnInputTextChanged(string? value) => await TranslateInputText();
    async partial void OnSelectedSourceLanguageChanged(Language? value) => await TranslateInputText();
    async partial void OnSelectedTargetLanguageChanged(Language? value) => await TranslateInputText();

    private async Task TranslateInputText()
    {
        if (SelectedSourceLanguage is null || SelectedTargetLanguage is null || InputText is null)
            return;

        var translationResult = await _translationService.Translate(InputText!, SelectedSourceLanguage, SelectedTargetLanguage!);
        if (!translationResult.IsSuccess)
            return; // TODO: Display Error

        TranslatedText = translationResult.TranslatedText;
    }

    internal void OnDisappearing()
    {
        //_translationService.Close()
    }
}
