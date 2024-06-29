using Android.Gms.Extensions;
using Java.Interop;
using Java.Lang;
using MLKit.Maui.Translate.Platforms.Android;
using Xamarin.Google.MLKit.Common.Model;
using Xamarin.Google.MLKit.NL.Translate;

namespace MLKit.Maui.Translate;

/// <summary>
/// The Android implementation of <see cref="ITranslationService"/>
/// </summary>
public class TranslationService : ITranslationService
{
    /// <inheritdoc />
    public async Task<DownloadResult> DownloadLanguageModel(Language sourceLanguage, DownloadOptions downloadOptions)
    {
        var downloadResult = new DownloadResult();

        var languageModel = new TranslateRemoteModel.Builder(sourceLanguage.Tag).Build();
        await RemoteModelManager.Instance.Download(languageModel, downloadOptions.ToAndroidDownloadConditions())
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                downloadResult = new DownloadResult(false, ex.Message);
            }));

        return downloadResult!;
    }

    /// <inheritdoc />
    public async Task<DeleteResult> DeleteLanguageModel(Language language)
    {
        var deleteResult = new DeleteResult();

        var languageModel = new TranslateRemoteModel.Builder(language.Tag).Build();
        var modelManager = RemoteModelManager.Instance;

        await modelManager.DeleteDownloadedModel(languageModel)
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                deleteResult = new DeleteResult(false, ex.Message);
            }));

        return deleteResult;
    }

    /// <inheritdoc />
    public async Task<List<Language>> GetDownloadedLanguageModels()
    {
        // Get TranslateRemoteModels
        var modelManager = RemoteModelManager.Instance;
        var result = await modelManager.GetDownloadedModels(Class.FromType(typeof(TranslateRemoteModel)));
        var javaSet = result.JavaCast<Java.Util.HashSet>();

        var languages = new List<Language>();

        // Transform from TranslateRemoteModels to Languages
        var modelIterator = javaSet.Iterator();
        while (modelIterator.HasNext)
        {
            var model = modelIterator.Next().JavaCast<TranslateRemoteModel>();
            if (model is null)
                continue;

            var language = Languages.LanguageFromTag(model.Language);
            if (language is not null)
                languages.Add(language);
        }

        return languages;
    }

    /// <inheritdoc />
    public async Task<TranslationResult> Translate(string text, Language sourceLanguage, Language targetLanguage)
    {
        TranslationResult? translationResult = null;

        // Get translator
        var options = new TranslatorOptions.Builder()
            .SetSourceLanguage(sourceLanguage.Tag)
            .SetTargetLanguage(targetLanguage.Tag)
            .Build();
        var translator = Translation.GetClient(options);

        // Translate the text
        await translator.Translate(text)
            .AddOnSuccessListener(new OnSuccessListener((translatedText) =>
            {
                translationResult = new(translatedText);
            }))
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                translationResult = new(null, false, ex.Message);
            }));

        translator.Close();
        return translationResult!;
    }
}
