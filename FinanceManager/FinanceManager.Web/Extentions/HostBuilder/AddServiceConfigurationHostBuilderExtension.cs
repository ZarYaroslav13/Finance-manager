using System.Globalization;
using Blazored.LocalStorage;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Authorization;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Preferences.Client;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Services.APIServices.TokenManager;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Services.Autorization.AuthenticationService;
using FinanceManager.Web.Services.HttpHandlers;
using FinanceManager.Web.Shared.Constants.Localization;
using FinanceManager.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Refit;

namespace FinanceManager.Web.Extentions.HostBuilder;

public static class AddServiceConfigurationHostBuilderExtension
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        services.Configure<APIOptions>(configuration.GetSection(APIOptions.Section));

        builder.AddDefaultServices();

        services
            .ConfigureLocalization()
            .AddAuthorization(RegisterPolicies)
            .AddBlazoredLocalStorage()
            .AddMudServices();

        builder.AdjustHttpClient();

        services.AddClientServices();

        return builder;
    }

    private static IHostApplicationBuilder AddDefaultServices(this IHostApplicationBuilder builder)
    {
        // Add service defaults & Aspire components.
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddOutputCache();
        return builder;
    }

    private static IServiceCollection ConfigureLocalization(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(opt =>
        {
            var suportedCultures = LocalizationConstants.SupportedLanguages.
                Select(l => new CultureInfo(l.Code))
                .ToList();

            opt.SupportedCultures = suportedCultures;
            opt.SupportedUICultures = suportedCultures;

            opt.DefaultRequestCulture = new("en-US");
        });

        services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

        return services;
    }

    private static IHostApplicationBuilder AdjustHttpClient(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration as IConfiguration;
        var options = configuration.GetSection(APIOptions.Section).Get<APIOptions>();

        builder.Services
        .AddTransient<HttpMessagesHandler>()
        .AddRefitClient<IFinanceManagerApiHttpClient>()
        .ConfigureHttpClient(opt =>
            {
                opt.BaseAddress = new(options.BaseAddress);
                opt.DefaultRequestHeaders.AcceptLanguage.Clear();
                opt.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
            })
        .AddHttpMessageHandler<HttpMessagesHandler>();

        return builder;
    }

    private static void RegisterPolicies(AuthorizationOptions options)
    {
        options.AddPolicy(PolicyManager.AdminPolicy, policy =>
        {
            policy.RequireRole(PolicyManager.AdminRole);
        });
    }

    private static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services
            .AddScoped<IPreferencesManager, ClientPreferencesManager>()
            .AddScoped<FinanceManagerStateProvider>()
            .AddScoped<AuthenticationStateProvider, FinanceManagerStateProvider>()
            .AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<ViewModelServicesLocator>();

        services.AddScoped<ITokenManager, TokenManager>();

        services.AddViewModels();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        var viewModelsType = typeof(IViewModel);

        var viewModels = viewModelsType.Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract);

        foreach (var viewModel in viewModels)
        {
            services.AddScoped(viewModel);
        }

        return services;
    }
}
