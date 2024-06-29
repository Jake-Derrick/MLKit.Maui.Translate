

namespace MLKit.Maui.Translate;

public class TranslationService : ITranslationService
{
    public Task<DeleteResult> DeleteLanguageModel(Language language)
    {
        throw new NotImplementedException();
    }

    public Task<DownloadResult> DownloadLanguageModel(Language sourceLanguage, DownloadOptions downloadOptions)
    {
        throw new NotImplementedException();
    }

    public Task<List<Language>> GetDownloadedLanguageModels()
    {
        throw new NotImplementedException();
    }

    public Task<TranslationResult> Translate(string text, Language sourceLanguage, Language targetLanguage)
    {
        throw new NotImplementedException();
    }
}
