namespace FinanceManager.Infrastructure.Constants.Localization;

public static class LocalizationConstants
{
    public static readonly LanguageCode EnglishLanguage = new() { Code = "en-US", DisplayName = "English" };
    public static readonly LanguageCode FrenchLanguage = new() { Code = "fr-FR", DisplayName = "French" };
    public static readonly LanguageCode KhmerLanguage = new() { Code = "km_KH", DisplayName = "Khmer" };
    public static readonly LanguageCode GermanLanguage = new() { Code = "de-DE", DisplayName = "German" };
    public static readonly LanguageCode SpanishLanguage = new() { Code = "es-ES", DisplayName = "Español" };
    public static readonly LanguageCode RussianLanguage = new() { Code = "ru-RU", DisplayName = "Русский" };
    public static readonly LanguageCode UkrainianLanguage = new() { Code = "uk-UA", DisplayName = "Українська" };
    public static readonly LanguageCode SwedishLanguage = new() { Code = "sv-SE", DisplayName = "Swedish" };
    public static readonly LanguageCode IndonesianLanguage = new() { Code = "id-ID", DisplayName = "Indonesia" };
    public static readonly LanguageCode ItalianLanguage = new() { Code = "it-IT", DisplayName = "Italian" };
    public static readonly LanguageCode ArabicLanguage = new() { Code = "ar-SA", DisplayName = "عربي" };
    public static readonly LanguageCode NederlandsLanguage = new() { Code = "nl-NL", DisplayName = "Nederlands" };


    public static readonly LanguageCode[] SupportedLanguages = {
        EnglishLanguage,
        FrenchLanguage,
        KhmerLanguage,
        GermanLanguage,
        SpanishLanguage,
        RussianLanguage,
        UkrainianLanguage,
        SwedishLanguage,
        IndonesianLanguage,
        ItalianLanguage,
        ArabicLanguage,
        NederlandsLanguage
};
}
