using Xamarin.Google.MLKit.Common.Model;

namespace MLKit.Maui.Translate.Platforms.Android;

public static class Extensions
{
    /// <summary>
    /// Converts <see cref="DownloadOptions"/> to Android specific <see cref="DownloadConditions"/> 
    /// </summary>
    /// <param name="downloadOptions"></param>
    /// <returns></returns>
    public static DownloadConditions ToAndroidDownloadConditions(this DownloadOptions downloadOptions)
    {
        var downloadConditions = new DownloadConditions.Builder();

        if (downloadOptions.RequireWifi)
            downloadConditions.RequireWifi();

        if (downloadOptions.RequireCharging)
            downloadConditions.RequireCharging();

        return downloadConditions.Build();
    }
}
