using Android.Gms.Tasks;

namespace MLKit.Maui.Translate;

internal class OnSuccessListener(Action<string> onSuccess) : Java.Lang.Object, IOnSuccessListener
{
    private readonly Action<string> _onSuccess = onSuccess;
    public void OnSuccess(Java.Lang.Object result) => _onSuccess(result.ToString());
}

internal class OnFailureListener(Action<Java.Lang.Exception> onFailure) : Java.Lang.Object, IOnFailureListener
{
    private readonly Action<Java.Lang.Exception> _onFailure = onFailure;
    public void OnFailure(Java.Lang.Exception e) => _onFailure(e);
}
