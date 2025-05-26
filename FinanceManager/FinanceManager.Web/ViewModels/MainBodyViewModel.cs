using FinanceManager.Application.Models;
using FinanceManager.Domain.API;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Services;
using FinanceManager.Web.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public class MainBodyViewModel : BaseViewModel<MainBody>
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public EventCallback OnDarkModeToggle { get; set; }

    [Parameter]
    public EventCallback<bool> OnRightToLeftToggle { get; set; }

    public bool DrawerOpen = true;
    public Guid CurrentUserId { get; set; }
    public string ImageDataUrl { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string SecondName { get; set; }
    public string Email { get; set; }
    public char FirstLetterOfName { get; set; }

    public bool RightToLeft = false;

    public Direction RightToLeftDirrection => RightToLeft ? Direction.Right : Direction.Left;

    private IPreferencesManager _preferencesManager;

    public MainBodyViewModel(IPreferencesManager preferencesManager, ViewModelServicesLocator locator, IStringLocalizer<MainBody> localizer) : base(locator, localizer)
    {
        _preferencesManager = preferencesManager ?? throw new ArgumentNullException(nameof(preferencesManager));
    }

    public async Task OnInitializedAsync()

    {
        RightToLeft = await _preferencesManager.IsRTL();
        _snackBar.Add(string.Format(Localizer["Welcome {0}"], FirstName), Severity.Success);
    }
    public async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadDataAsync();
        }
    }

    public async Task RightToLeftToggle()
    {
        var isRtl = await _preferencesManager.ToggleLayoutDirection();
        RightToLeft = isRtl;

        await OnRightToLeftToggle.InvokeAsync(isRtl);
    }

    public async Task ToggleDarkMode()
    {
        await OnDarkModeToggle.InvokeAsync();
    }

    public async Task LoadDataAsync()
    {
        var user = await _authenticationService.CurrentUserAsync();
        if (user == null) return;
        if (user.Identity?.IsAuthenticated == true)
        {
            if (CurrentUserId == Guid.Empty)
            {
                CurrentUserId = new(user.GetUserId());
                FirstName = user.GetFirstName();
                if (FirstName.Length > 0)
                {
                    FirstLetterOfName = FirstName[0];
                }

                SecondName = user.GetLastName();
                Email = user.GetEmail();

                var currentUserResult = await (await _httpClient.GetAsync(APIEndpoints.Users.Get(CurrentUserId))).ToResultAsync<TokenDTO>();
                if (!currentUserResult.Succeeded || currentUserResult.Data == null)
                {
                    _snackBar.Add(
                        Localizer["You are logged out because the user with your Token has been deleted."],
                        Severity.Error);
                    CurrentUserId = Guid.Empty;
                    ImageDataUrl = string.Empty;
                    FirstName = string.Empty;
                    SecondName = string.Empty;
                    Email = string.Empty;
                    FirstLetterOfName = char.MinValue;
                    await _authenticationService.LogoutAsync();
                }
            }
        }
    }

    public void DrawerToggle()
    {
        DrawerOpen = !DrawerOpen;
    }

    public async Task LogoutAsync()
    {
        var parameters = new DialogParameters
        {
                {nameof(Shared.Dialogs.Logout.Logout.ContentText), $"{Localizer["Logout Confirmation"]}"},
                {nameof(Shared.Dialogs.Logout.Logout.ButtonText), $"{Localizer["Logout"]}"},
                {nameof(Shared.Dialogs.Logout.Logout.Color), Color.Error}
            };

        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

        await _dialogService.ShowAsync<Shared.Dialogs.Logout.Logout>(Localizer["Logout"], parameters, options);
    }
}
