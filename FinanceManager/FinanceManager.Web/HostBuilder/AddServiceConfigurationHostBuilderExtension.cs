using Blazored.LocalStorage;
using FinanceManager.Domain.Authorization;
using FinanceManager.Web.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using System.Security.Claims;

namespace FinanceManager.Web.HostBuilder;

public static class AddServiceConfigurationHostBuilderExtension
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        builder.AddDefaultServices();

        services
            .AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            })
            .AddAuthorization(RegisterPolicies)
            .AddBlazoredLocalStorage()
            .AddMudServices();

        services.Configure<APIOptions>(configuration.GetSection(APIOptions.Section));

        builder.AdjustHttpClient();

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

    private static IHostApplicationBuilder AdjustHttpClient(this IHostApplicationBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<APIOptions>>().Value;
        builder.Services.AddHttpClient<HttpClient>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new(options.BaseAddress);
        });

        return builder;
    }

    private static void RegisterPolicies(AuthorizationOptions options)
    {
        options.AddPolicy(PolicyManager.AdminPolicy, policy =>
        {
            policy.RequireClaim(ClaimTypes.Role, PolicyManager.AdminRole);
        });
    }
}
