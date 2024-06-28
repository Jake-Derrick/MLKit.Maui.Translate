

namespace MLKit.Maui.Translate;

#if !ANDROID && !IOS
// See the Platforms folder for the device specific implementation of this service.
/// <summary>
/// The plain .Net implementation of <see cref="ITranslationService"/>.
/// </summary>
public class TranslationService : ITranslationService
{
    public Task<DeleteResult> DeleteLanguageModel(string language) => throw new NotImplementedException();
    public Task<DownloadResult> DownloadLanguageModel(string sourceLanguage, DownloadOptions downloadOptions) => throw new NotImplementedException();
    public Task<List<string>> GetDownloadedLanguageModels() => throw new NotImplementedException();
    public Task<TranslationResult> Translate(string text, string sourceLanguage, string targetLanguage) => throw new NotImplementedException();
}
#endif
