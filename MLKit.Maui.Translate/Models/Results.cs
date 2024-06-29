namespace MLKit.Maui.Translate;

public record BaseResult(bool IsSuccess = true, string? ErrorMessage = null);
public record TranslationResult(string? TranslatedText, bool IsSuccess = true, string? ErrorMessage = null) : BaseResult(IsSuccess, ErrorMessage);
public record DownloadResult(bool IsSuccess = true, string? ErrorMessage = null) : BaseResult(IsSuccess, ErrorMessage);
public record DeleteResult(bool IsSuccess = true, string? ErrorMessage = null) : BaseResult(IsSuccess, ErrorMessage);

