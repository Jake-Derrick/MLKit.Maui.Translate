namespace MLKit.Maui.Translate;

public interface ITranslationService
{
    /// <summary>
    /// Downloads a translation model for the specified source language.
    /// </summary>
    Task<DownloadResult> DownloadLanguageModel(Language sourceLanguage, DownloadOptions downloadOptions);

    /// <summary>
    /// Deletes the translation model associated with the specified language.
    /// </summary>
    Task<DeleteResult> DeleteLanguageModel(Language language);

    /// <summary>
    /// Retrieves the languages for which translation models are stored locally on the device.
    /// </summary>
    Task<List<Language>> GetDownloadedLanguageModels();

    /// <summary>
    /// Translates the specified text from the source language to the target language.
    /// </summary>
    /// <remarks>
    /// If the translation model for either the source or target language is not already downloaded, it will attempt to download it before performing the translation.
    /// </remarks>
    Task<TranslationResult> Translate(string text, Language sourceLanguage, Language targetLanguage);
}
