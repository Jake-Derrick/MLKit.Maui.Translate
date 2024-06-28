
namespace MLKit.Maui.Translate;

public class TranslationService : ITranslationService
{
    public Task<DeleteResult> DeleteLanguageModel(string language)
    {
        throw new NotImplementedException();
    }

    public Task<DownloadResult> DownloadLanguageModel(string sourceLanguage, DownloadOptions downloadOptions)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetDownloadedLanguageModels()
    {
        throw new NotImplementedException();
    }

    public Task<TranslationResult> Translate(string text, string sourceLanguage, string targetLanguage)
    {
        throw new NotImplementedException();
    }
}
