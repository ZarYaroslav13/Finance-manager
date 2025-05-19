using Blazored.LocalStorage;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace FinanceManager.Web.Extentions;

public static class HubConnectionEtention
{
    public static HubConnection TryInitialize(this HubConnection connection, NavigationManager navigationManager, ILocalStorageService localStorage)
    {
        if (connection == null)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/signalRHub"), opt =>
                {
                    opt.AccessTokenProvider = async () => await localStorage.GetItemAsync<string>(StorageConstants.AuthToken);
                })
                .WithAutomaticReconnect()
                .Build();
        }
        return connection;
    }
}
