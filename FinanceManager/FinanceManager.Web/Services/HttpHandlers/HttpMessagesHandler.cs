using System.Net.Http.Headers;
using FinanceManager.Domain.API;
using FinanceManager.Web.Services.Autorization.AuthenticationService;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.Services.HttpHandlers;

public class HttpMessagesHandler : DelegatingHandler
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IStringLocalizer<HttpMessagesHandler> _localizer;
    private readonly NavigationManager _navigationManager;
    private readonly ILogger<HttpMessagesHandler> _logger;

    public HttpMessagesHandler(
        IServiceScopeFactory serviceScopeFactory,
        IStringLocalizer<HttpMessagesHandler> localizer,
        NavigationManager navigationManager,
        ILogger<HttpMessagesHandler> logger)
    {
        _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var path = request.RequestUri.AbsolutePath;

        if (IsEndpointNeedToken(path))
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var authenticationService = scope.ServiceProvider.GetService<IAuthenticationService>();

                try
                {
                    var token = await authenticationService.TryRefreshTokenAsync();
                    if (!string.IsNullOrEmpty(token))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await authenticationService.LogoutAsync();
                    _navigationManager.NavigateTo("/");
                }
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }

    private bool IsEndpointNeedToken(string path)
    {
        return !path.Contains(APIEndpoints.Token.BaseControllerUrl)
            && !path.Contains(APIEndpoints.Users.ForgotPassword)
            && !path.Contains(APIEndpoints.Users.ResetPassword)
            && !path.Contains(APIEndpoints.Users.ConfirmEmail);
    }
}
