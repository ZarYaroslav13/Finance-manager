using FinanceManager.Application.Models;
using FinanceManager.Web.Components.Pages.Tools.FinanceOperationTypes;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Tools.FinanceOperationTypes;

public class FinanceOperationTypesPageViewModel : BaseViewModel<FinanceOperationTypesPage>
{
    public static class SortLabels
    {
        public const string Name = nameof(FinanceOperationTypeDTO.Name);
        public const string Description = nameof(FinanceOperationTypeDTO.Description);
        public const string EntryType = nameof(FinanceOperationTypeDTO.EntryType);
        public const string WalletName = nameof(FinanceOperationTypeDTO.WalletName);
    }

    public Guid WalletId { get; set; }

    public List<FinanceOperationTypeDTO> TableData { get; set; } = new();

    public Dictionary<string, Func<FinanceOperationTypeDTO, object>> SortFunctions = new()
    {
        { SortLabels.Name, type => type.Name },
        { SortLabels.Description, type => type.Description },
        { SortLabels.EntryType, type => type.EntryType },
        { SortLabels.WalletName, type => type.WalletName },
    };

    private readonly IWalletManager _walletManager;
    private readonly IFinanceOperationTypeManager _financeOperationTypeManager;

    public FinanceOperationTypesPageViewModel(IFinanceOperationTypeManager financeOperationTypeManager, IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<FinanceOperationTypesPage> localizer) : base(locator, localizer)
    {
        _financeOperationTypeManager = financeOperationTypeManager ?? throw new ArgumentNullException(nameof(financeOperationTypeManager));
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));
    }

    public async Task<TableData<FinanceOperationTypeDTO>> LoadData(TableState state, CancellationToken token)
    {
        var result = new List<FinanceOperationTypeDTO>();

        if (WalletId == Guid.Empty)
        {
            var wallets = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

            foreach (var wallet in wallets.Data)
            {
                result.AddRange((await _financeOperationTypeManager.GetAllTypesOfWalletAsync(wallet.Id)).Data);
            }
        }
        else
        {
            result = (await _financeOperationTypeManager.GetAllTypesOfWalletAsync(WalletId)).Data;
        }

        return new() { TotalItems = result.Count, Items = result };
    }

    public async Task OnInitializedAsync()
    {
        var result = new List<FinanceOperationTypeDTO>();

        if (WalletId == Guid.Empty)
        {
            var wallets = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

            foreach (var wallet in wallets.Data)
            {
                result.AddRange((await _financeOperationTypeManager.GetAllTypesOfWalletAsync(wallet.Id)).Data);
            }
        }
        else
        {
            result = (await _financeOperationTypeManager.GetAllTypesOfWalletAsync(WalletId)).Data;
        }

        TableData.AddRange(result);
    }


}
