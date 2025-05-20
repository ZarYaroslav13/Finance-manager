using System.Net.Http.Headers;
using FinanceManager.Domain.API;
using FinanceManager.Web.Services.Autorization.AuthenticationService;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.Services.HttpHandlers;

public class HttpMessagesHandler : DelegatingHandler
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ISnackbar _snackBar;
    private readonly IStringLocalizer<HttpMessagesHandler> _localizer;
    private readonly NavigationManager _navigationManager;
    private readonly ILogger<HttpMessagesHandler> _logger;

    public HttpMessagesHandler(
        IAuthenticationService authenticationService,
        ISnackbar snackBar,
        IStringLocalizer<HttpMessagesHandler> localizer,
        NavigationManager navigationManager,
        ILogger<HttpMessagesHandler> logger)
    {
        _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        _snackBar = snackBar ?? throw new ArgumentNullException(nameof(_snackBar));
        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var path = request.RequestUri.AbsolutePath;

        if (IsEndpointNeedToken(path))
        {
            try
            {
                var token = await _authenticationService.TryRefreshTokenAsync();
                if (!string.IsNullOrEmpty(token))
                {
                    _snackBar.Add(_localizer["Refreshed Token."], Severity.Success);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _snackBar.Add(_localizer["You are Logged Out."], Severity.Error);
                await _authenticationService.LogoutAsync();
                _navigationManager.NavigateTo("/");
            }

        }

        return await base.SendAsync(request, cancellationToken);
    }

    private bool IsEndpointNeedToken(string path)
    {
        return !path.Contains(ApiEndpoints.Login.BaseControllerUrl);
    }
}
