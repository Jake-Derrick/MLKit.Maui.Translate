using CommunityToolkit.Mvvm.ComponentModel;
using MLKit.Maui.Translate;
using System.ComponentModel;
using System.Windows.Input;

namespace Example.App;

public partial class TranslationExampleViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly ITranslationService _translationService;
    public ICommand TranslateCommand { get; protected set; }

    public TranslationExampleViewModel(ITranslationService translationService)
    {
        _translationService = translationService;
        TranslateCommand = new Command(TranslateClicked);
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonEnabled))]
    private string _selectedSourceLanguage = Languages.English;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonEnabled))]
    private string? _selectedTargetLanguage;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonEnabled))]
    private string? _inputText;

    [ObservableProperty]
    private string? _translatedText;

    [ObservableProperty]
    private List<string> _availableLanguages = [Languages.English, Languages.Spanish, Languages.German];

    private bool ButtonEnabled => SelectedSourceLanguage is not null && SelectedTargetLanguage is not null && InputText is not null;

    private async void TranslateClicked()
    {
        var translationResult = await _translationService.Translate(InputText!, SelectedSourceLanguage, SelectedTargetLanguage!);
        if (!translationResult.IsSuccess)
            return; // TODO: Display Error

        TranslatedText = translationResult.TranslatedText;
    }
}
