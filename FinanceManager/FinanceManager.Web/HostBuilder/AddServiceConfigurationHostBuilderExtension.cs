using FinanceManager.Web.API;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

namespace FinanceManager.Web.HostBuilder;

public static class AddServiceConfigurationHostBuilderExtension
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        builder.AddDefaultServices();

        builder.Services.AddMudServices();

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
}
