using System.Globalization;
using FinanceManager.Web;
using FinanceManager.Web.Extentions.HostBuilder;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Preferences.Client;
using FinanceManager.Web.Shared.Constants.Localization;

public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServices();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.UseOutputCache();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.MapDefaultEndpoints();

        await app.RunAsync();
        await SetPreferences(app);
    }

    private static async Task SetPreferences(WebApplication app)
    {
        var storageService = app.Services.GetRequiredService<IPreferencesManager>();
        if (storageService != null)
        {
            CultureInfo culture;
            var preference = await storageService.GetPreference() as ClientPreferences;
            if (preference != null)
                culture = new CultureInfo(preference.LanguageCode);
            else
                culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}