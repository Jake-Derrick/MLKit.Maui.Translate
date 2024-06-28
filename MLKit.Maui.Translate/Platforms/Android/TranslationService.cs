using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Java.Interop;
using Java.Lang;
using MLKit.Maui.Translate.Platforms.Android;
using Xamarin.Google.MLKit.Common.Model;
using Xamarin.Google.MLKit.NL.Translate;

namespace MLKit.Maui.Translate;

public class TranslationService : ITranslationService
{
    public async Task<DownloadResult> DownloadLanguageModel(string sourceLanguage, DownloadOptions downloadOptions)
    {
        var downloadResult = new DownloadResult();

        var languageModel = new TranslateRemoteModel.Builder(sourceLanguage).Build();
        await RemoteModelManager.Instance.Download(languageModel, downloadOptions.ToAndroidDownloadConditions())
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                downloadResult = new DownloadResult(false, ex.Message);
            }));

        return downloadResult!;
    }

    public async Task<DeleteResult> DeleteLanguageModel(string language)
    {
        var deleteResult = new DeleteResult();

        var languageModel = new TranslateRemoteModel.Builder(language).Build();
        var modelManager = RemoteModelManager.Instance;

        await modelManager.DeleteDownloadedModel(languageModel)
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                deleteResult = new DeleteResult(false, ex.Message);
            }));

        return deleteResult;
    }

    public async Task<List<string>> GetDownloadedLanguageModels()
    {
        var modelManager = RemoteModelManager.Instance;
        var result = await modelManager.GetDownloadedModels(Class.FromType(typeof(TranslateRemoteModel)));
        var javaSet = result.JavaCast<Java.Util.HashSet>();

        var models = new HashSet<TranslateRemoteModel>();
        var iterator = javaSet.Iterator();
        while (iterator.HasNext)
        {
            var item = iterator.Next().JavaCast<TranslateRemoteModel>();
            if (item is not null)
                models.Add(item);
        }

        return models.Select(model => model.Language).ToList();
    }

    public async Task<TranslationResult> Translate(string text, string sourceLanguage, string targetLanguage)
    {
        TranslationResult? translationResult = null;

        // Get translator
        var options = new TranslatorOptions.Builder()
            .SetSourceLanguage(sourceLanguage)
            .SetTargetLanguage(targetLanguage)
            .Build();
        var translator = Translation.GetClient(options);

        // Download Language Models
        await translator.DownloadModelIfNeeded(DownloadOptions.Default.ToAndroidDownloadConditions())
            .AddOnFailureListener(new OnFailureListener((ex) =>
            {
                translationResult = new(null, false, ex.Message);
            }));

        if (translationResult is not null)
            return translationResult;

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

        return translationResult!;
    }

    public void CloseTranslator()
    {
        var options = new TranslatorOptions.Builder()
            .SetSourceLanguage(Languages.English)
            .SetTargetLanguage(Languages.Spanish)
            .Build();

        var translator = Translation.GetClient(options);
        translator.Close();
    }
}

public class OnSuccessListener(Action<string> onSuccess) : Java.Lang.Object, IOnSuccessListener
{
    private readonly Action<string> _onSuccess = onSuccess;

    public void OnSuccess(Java.Lang.Object result)
    {
        _onSuccess(result.ToString());
    }
}

public class OnFailureListener(Action<Java.Lang.Exception> onFailure) : Java.Lang.Object, IOnFailureListener
{
    private readonly Action<Java.Lang.Exception> _onFailure = onFailure;

    public void OnFailure(Java.Lang.Exception e)
    {
        _onFailure(e);
    }
}
