using FinanceManager.Web.Extentions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Shared.Components;

public partial class UserCard
{
    [Parameter] public string Class { get; set; }
    private string FirstName { get; set; }
    private string SecondName { get; set; }
    private string Email { get; set; }
    private char FirstLetterOfName { get; set; } = '-';

    protected override async Task OnInitializedAsync()
    {
        //_stateProvider.AuthenticationStateChanged += OnAuthenticationStateChanged;
        await LoadDataAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    }

    private async void OnAuthenticationStateChanged(Task<AuthenticationState> state)
    {
        await InvokeAsync(async () =>
        {
            await LoadDataAsync();

            StateHasChanged();
        });
    }

    private async Task LoadDataAsync()
    {
        var state = await _stateProvider.GetAuthenticationStateAsync();
        var user = state.User;

        Email = user.GetEmail().Replace(".com", string.Empty);
        FirstName = user.GetFirstName();
        SecondName = user.GetLastName();
        if (FirstName.Length > 0)
        {
            FirstLetterOfName = FirstName[0];
        }
        var UserId = user.GetUserId();
        StateHasChanged();
    }
}