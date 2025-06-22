using Blazored.LocalStorage;
using CsvHelper.Configuration;
using FinanceManager.Application.UseCases.Commons.Mapping;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Infrastructure.Constants.Localization;
using FinanceManager.Web.Pages;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Preferences.Client;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Services.APIServices.Managers;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Services.HttpHandlers;
using FinanceManager.Web.Services.Reports.Generetors;
using FinanceManager.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using Refit;
using System.Globalization;

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
            .ConfigureAuthentication();

        services.AddAuthorization(RegisterPolicies)
            .AddHttpContextAccessor()
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

            opt.DefaultRequestCulture = new(LocalizationConstants.EnglishLanguage.Code);
        });

        services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

        return services;
    }

    private static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = PagesHref.Authentication.Login;
                options.Cookie.Name = "FMAuthCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = PagesHref.Authentication.Login;
            });

        services.AddCascadingAuthenticationState();
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
        services.AddAutoMapper(typeof(UsertProfile).Assembly);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services
            .AddScoped<IPreferencesManager, ClientPreferencesManager>()
            .AddScoped<FinanceManagerStateProvider>()
            .AddScoped<AuthenticationStateProvider, FinanceManagerStateProvider>();

        services
            .AddManagers()
            .AddFinancialReportCreators()
            .AddScoped<ViewModelServicesLocator>()
            .AddViewModels();

        return services;
    }

    private static IServiceCollection AddFinancialReportCreators(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var culture = httpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture
                          ?? CultureInfo.CurrentCulture;

            var delimiter = culture.NumberFormat.NumberDecimalSeparator;

            return new CsvConfiguration(culture)
            {
                NewLine = Environment.NewLine,
                Delimiter = delimiter
            };
        });

        services.AddScoped<CSVGenerator>();

        services.AddScoped<ReportGeneretorsLocator>();

        return services;
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        var managersTypes = typeof(IManager);

        var managers = managersTypes.Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t != null);

        foreach (var manager in managers)
        {
            if (managersTypes.IsAssignableFrom(manager.Service))
                services.AddTransient(manager.Service, manager.Implementation);
        }

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
            services.AddTransient(viewModel);
        }

        return services;
    }
}
