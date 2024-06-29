namespace MLKit.Maui.Translate;

/// <summary>
/// Represents a language with its BCP 47 language tag and readable name.
/// </summary>
/// <param name="Name">The readable language name.</param>
/// <param name="Tag">The BCP 47 language tag.</param>
public record Language(string Name, string Tag);

/// <summary>
/// Supported language values.
/// </summary>
public static class Languages
{
    /// <summary>Afrikaans (af)</summary>
    public static Language Afrikaans => new("Afrikaans", "af");

    /// <summary>Albanian (sq)</summary>
    public static Language Albanian => new("Albanian", "sq");

    /// <summary>Arabic (ar)</summary>
    public static Language Arabic => new("Arabic", "ar");

    /// <summary>Belarusian (be)</summary>
    public static Language Belarusian => new("Belarusian", "be");

    /// <summary>Bengali (bn). Also known as Bangla.</summary>
    public static Language Bengali => new("Bengali", "bn");

    /// <summary>Bulgarian (bg)</summary>
    public static Language Bulgarian => new("Bulgarian", "bg");

    /// <summary>Catalan (ca)</summary>
    public static Language Catalan => new("Catalan", "ca");

    /// <summary>Chinese (zh)</summary>
    public static Language Chinese => new("Chinese", "zh");

    /// <summary>Croatian (hr)</summary>
    public static Language Croatian => new("Croatian", "hr");

    /// <summary>Czech (cs)</summary>
    public static Language Czech => new("Czech", "cs");

    /// <summary>Danish (da)</summary>
    public static Language Danish => new("Danish", "da");

    /// <summary>Dutch (nl)</summary>
    public static Language Dutch => new("Dutch", "nl");

    /// <summary>English (en)</summary>
    public static Language English => new("English", "en");

    /// <summary>Esperanto (eo)</summary>
    public static Language Esperanto => new("Esperanto", "eo");

    /// <summary>Estonian (et)</summary>
    public static Language Estonian => new("Estonian", "et");

    /// <summary>Finnish (fi)</summary>
    public static Language Finnish => new("Finnish", "fi");

    /// <summary>French (fr)</summary>
    public static Language French => new("French", "fr");

    /// <summary>Galician (gl)</summary>
    public static Language Galician => new("Galician", "gl");

    /// <summary>Georgian (ka)</summary>
    public static Language Georgian => new("Georgian", "ka");

    /// <summary>German (de)</summary>
    public static Language German => new("German", "de");

    /// <summary>Greek (el)</summary>
    public static Language Greek => new("Greek", "el");

    /// <summary>Gujarati (gu)</summary>
    public static Language Gujarati => new("Gujarati", "gu");

    /// <summary>Haitian Creole (ht)</summary>
    public static Language Haitian_Creole => new("Haitian Creole", "ht");

    /// <summary>Hebrew (he)</summary>
    public static Language Hebrew => new("Hebrew", "he");

    /// <summary>Hindi (hi)</summary>
    public static Language Hindi => new("Hindi", "hi");

    /// <summary>Hungarian (hu)</summary>
    public static Language Hungarian => new("Hungarian", "hu");

    /// <summary>Icelandic (is)</summary>
    public static Language Icelandic => new("Icelandic", "is");

    /// <summary>Indonesian (id)</summary>
    public static Language Indonesian => new("Indonesian", "id");

    /// <summary>Irish (ga)</summary>
    public static Language Irish => new("Irish", "ga");

    /// <summary>Italian (it)</summary>
    public static Language Italian => new("Italian", "it");

    /// <summary>Japanese (ja)</summary>
    public static Language Japanese => new("Japanese", "ja");

    /// <summary>Kannada (kn)</summary>
    public static Language Kannada => new("Kannada", "kn");

    /// <summary>Korean (ko)</summary>
    public static Language Korean => new("Korean", "ko");

    /// <summary>Latvian (lv)</summary>
    public static Language Latvian => new("Latvian", "lv");

    /// <summary>Lithuanian (lt)</summary>
    public static Language Lithuanian => new("Lithuanian", "lt");

    /// <summary>Macedonian (mk)</summary>
    public static Language Macedonian => new("Macedonian", "mk");

    /// <summary>Malay (ms)</summary>
    public static Language Malay => new("Malay", "ms");

    /// <summary>Maltese (mt)</summary>
    public static Language Maltese => new("Maltese", "mt");

    /// <summary>Marathi (mr)</summary>
    public static Language Marathi => new("Marathi", "mr");

    /// <summary>Norwegian (no)</summary>
    public static Language Norwegian => new("Norwegian", "no");

    /// <summary>Persian (fa). Also known as Farsi.</summary>
    public static Language Persian => new("Persian", "fa");

    /// <summary>Polish (pl)</summary>
    public static Language Polish => new("Polish", "pl");

    /// <summary>Portuguese (pt)</summary>
    public static Language Portuguese => new("Portuguese", "pt");

    /// <summary>Romanian (ro)</summary>
    public static Language Romanian => new("Romanian", "ro");

    /// <summary>Russian (ru)</summary>
    public static Language Russian => new("Russian", "ru");

    /// <summary>Slovak (sk)</summary>
    public static Language Slovak => new("Slovak", "sk");

    /// <summary>Slovenian (sl)</summary>
    public static Language Slovenian => new("Slovenian", "sl");

    /// <summary>Spanish (es)</summary>
    public static Language Spanish => new("Spanish", "es");

    /// <summary>Swahili (sw)</summary>
    public static Language Swahili => new("Swahili", "sw");

    /// <summary>Swedish (sv)</summary>
    public static Language Swedish => new("Swedish", "sv");

    /// <summary>Tagalog (tl)</summary>
    public static Language Tagalog => new("Tagalog", "tl");

    /// <summary>Tamil (ta)</summary>
    public static Language Tamil => new("Tamil", "ta");

    /// <summary>Telugu (te)</summary>
    public static Language Telugu => new("Telugu", "te");

    /// <summary>Thai (th)</summary>
    public static Language Thai => new("Thai", "th");

    /// <summary>Turkish (tr)</summary>
    public static Language Turkish => new("Turkish", "tr");

    /// <summary>Ukrainian (uk)</summary>
    public static Language Ukrainian => new("Ukrainian", "uk");

    /// <summary>Urdu (ur)</summary>
    public static Language Urdu => new("Urdu", "ur");

    /// <summary>Vietnamese (vi)</summary>
    public static Language Vietnamese => new("Vietnamese", "vi");

    /// <summary>Welsh (cy)</summary>
    public static Language Welsh => new("Welsh", "cy");

    /// <summary>
    /// A collection of all supported languages.
    /// </summary>
    public static List<Language> AllLanguages =>
    [
        Afrikaans,
        Albanian,
        Arabic,
        Belarusian,
        Bengali,
        Bulgarian,
        Catalan,
        Chinese,
        Croatian,
        Czech,
        Danish,
        Dutch,
        English,
        Esperanto,
        Estonian,
        Finnish,
        French,
        Galician,
        Georgian,
        German,
        Greek,
        Gujarati,
        Haitian_Creole,
        Hebrew,
        Hindi,
        Hungarian,
        Icelandic,
        Indonesian,
        Irish,
        Italian,
        Japanese,
        Kannada,
        Korean,
        Latvian,
        Lithuanian,
        Macedonian,
        Malay,
        Maltese,
        Marathi,
        Norwegian,
        Persian,
        Polish,
        Portuguese,
        Romanian,
        Russian,
        Slovak,
        Slovenian,
        Spanish,
        Swahili,
        Swedish,
        Tagalog,
        Tamil,
        Telugu,
        Thai,
        Turkish,
        Ukrainian,
        Urdu,
        Vietnamese,
        Welsh
    ];

    /// <summary>
    /// Finds and returns the language corresponding to the given BCP 47 language tag.
    /// </summary>
    /// <param name="tag">The BCP 47 language tag to search for.</param>
    /// <returns>The corresponding <see cref="Language"/> object if found; otherwise <c>null</c>.</returns>
    public static Language? LanguageFromTag(string tag) => AllLanguages.FirstOrDefault(language => language.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
}

