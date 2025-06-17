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
    public static class TableLabels
    {
        public const string Name = nameof(FinanceOperationTypeDTO.Name);
        public const string Description = nameof(FinanceOperationTypeDTO.Description);
        public const string EntryType = nameof(FinanceOperationTypeDTO.EntryType);
        public const string WalletName = nameof(FinanceOperationTypeDTO.WalletName);

        public readonly static List<string> Labels = new()
        {
            Name, Description, EntryType, WalletName
        };
    }

    public Guid WalletId { get; set; }

    private List<FinanceOperationTypeDTO> _tableData = new();
    public List<FinanceOperationTypeDTO> TableData { get; set; } = new();

    public Dictionary<string, Func<FinanceOperationTypeDTO, object>> SortFunctions { get; } = new()
    {
        { TableLabels.Name, type => type.Name },
        { TableLabels.Description, type => type.Description },
        { TableLabels.EntryType, type => type.EntryType },
        { TableLabels.WalletName, type => type.WalletName },
    };

    public Dictionary<string, string> LocalizedTableLabels { get; } = new();

    private string _filterProperty = String.Empty;
    public string FilterProperty
    {
        get => _filterProperty;
        set
        {
            if(_filterProperty == value) return;

            _filterProperty = value;

            Filter();
        }
    }

    private string _filterValue = String.Empty;
    public string FilterValue
    {
        get => _filterValue;
        set
        {
            if (_filterValue == value) return;

            _filterValue = value;

            Filter();
        }
    }

    #region Grouping

    public TableGroupDefinition<FinanceOperationTypeDTO> GroupDefinition { get; }

    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceOperationTypeManager _financeOperationTypeManager;

    public FinanceOperationTypesPageViewModel(IFinanceOperationTypeManager financeOperationTypeManager, IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<FinanceOperationTypesPage> localizer) : base(locator, localizer)
    {
        _financeOperationTypeManager = financeOperationTypeManager ?? throw new ArgumentNullException(nameof(financeOperationTypeManager));
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));

        GroupDefinition = new()
        {
            GroupName = Localizer["Wallet"],
            Indentation = false,
            Expandable = true,
            IsInitiallyExpanded = false,
            Selector = (e) => e.WalletName
        };

        LocalizedTableLabels.Add(String.Empty, String.Empty);

        foreach (var item in TableLabels.Labels)
        {
            LocalizedTableLabels.Add(item, Localizer[item]);
        }
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
        _tableData = new();
        if (WalletId == Guid.Empty)
        {
            var wallets = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

            foreach (var wallet in wallets.Data)
            {
                _tableData.AddRange((await _financeOperationTypeManager.GetAllTypesOfWalletAsync(wallet.Id)).Data);
            }
        }
        else
        {
            _tableData = (await _financeOperationTypeManager.GetAllTypesOfWalletAsync(WalletId)).Data;
        }

        TableData.AddRange(_tableData);
    }

    public void Filter()
    {
        if(FilterValue == String.Empty || FilterProperty == String.Empty)
        {
            TableData = _tableData;
            return;
        }

        TableData = _tableData.Where(
                type =>
                {
                    var t = type.GetType();
                    var field = LocalizedTableLabels.FirstOrDefault(l => l.Value == _filterProperty).Key;
                    var value = t.GetProperty(field).GetValue(type).ToString().ToLower();
                    
                    return value.Contains(_filterValue.ToLower());
                })
            .ToList();

    }
}
