namespace MLKit.Maui.Translate;

/// <summary>
/// Represents the download options for language models.
/// </summary>
/// <param name="RequireWifi">Indicates whether language models should only be downloaded over Wi-Fi.</param>
/// <param name="RequireCharging">Indicates whether language models should only be downloaded while the device is charging.</param>
public record DownloadOptions(bool RequireWifi, bool RequireCharging)
{
    /// <summary>
    /// Gets the default download options.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><c>RequireWifi</c> is <c>true</c></item>
    /// <item><c>RequireCharging</c> is <c>false</c></item>
    /// </list>
    /// </remarks>
    public static DownloadOptions Default { get; } = new(RequireWifi: true, RequireCharging: false);
}
