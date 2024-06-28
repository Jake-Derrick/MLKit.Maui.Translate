namespace MLKit.Maui.Translate;

public interface ITranslationService
{
    Task<DownloadResult> DownloadLanguageModel(string sourceLanguage, DownloadOptions downloadOptions);

    Task<DeleteResult> DeleteLanguageModel(string language);

    Task<List<string>> GetDownloadedLanguageModels();

    Task<TranslationResult> Translate(string text, string sourceLanguage, string targetLanguage);
}
