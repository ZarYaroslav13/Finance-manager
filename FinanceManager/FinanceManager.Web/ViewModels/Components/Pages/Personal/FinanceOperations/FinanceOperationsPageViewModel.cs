using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Web.Components.Pages.Personal.FinanceOperations;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.FinancialOperationTypes;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Personal.FinanceOperations;

public class FinanceOperationsPageViewModel : BaseViewModel<FinanceOperationsPage>
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

    public Guid TypeId { get; set; }

    public List<WalletDTO> Wallets { get; private set; } = new();

    private List<FinanceOperationTypeDTO> _tableData = new();
    public MudTable<FinanceOperationTypeDTO> TableData { get; set; } = new();

    public Dictionary<string, Func<FinanceOperationTypeDTO, object>> SortFunctions { get; } = new()
    {
        { TableLabels.Name, type => type.Name },
        { TableLabels.Description, type => type.Description },
        { TableLabels.EntryType, type => type.EntryType },
        { TableLabels.WalletName, type => type.WalletName },
    };

    public Dictionary<string, string> LocalizedTableLabels { get; } = new();

    #region Filtering
    private string _filterProperty = String.Empty;
    public string FilterProperty
    {
        get => _filterProperty;
        set
        {
            if (_filterProperty == value) return;

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
    #endregion

    #region Grouping

    public TableGroupDefinition<FinanceOperationTypeDTO> GroupDefinition { get; }

    #endregion

    #region Updating
    private FinanceOperationDTO _typeBackup { get; set; }


    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceOperationTypeManager _financeOperationTypeManager;

    public FinanceOperationsPageViewModel(IFinanceOperationTypeManager financeOperationTypeManager, IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<FinanceOperationsPage> localizer) : base(locator, localizer)
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

    public async Task OnInitializedAsync()
    {
        _tableData = new();

        Wallets = (await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()))).Data;

        foreach (var wallet in Wallets)
        {
            _tableData.AddRange((await _financeOperationTypeManager.GetAllTypesOfWalletAsync(wallet.Id)).Data);
        }

        if (TypeId != Guid.Empty)
        {
            TableData.Items = _tableData.Where(t => t.WalletId == TypeId);
            return;
        }

        TableData.Items = _tableData;
    }

    public void Filter()
    {
        if (FilterValue == String.Empty || FilterProperty == String.Empty)
        {
            TableData.Items = _tableData;
            return;
        }

        TableData.Items = _tableData.Where(
                type =>
                {
                    var t = type.GetType();
                    var field = LocalizedTableLabels.FirstOrDefault(l => l.Value == _filterProperty).Key;
                    var value = t.GetProperty(field).GetValue(type).ToString().ToLower();

                    return value.Contains(_filterValue.ToLower());
                })
            .ToList();

    }

    public async Task CreateFinancialType()
    {
        var dialog = (DialogReference)await _dialogService.ShowAsync<AddFinancialTypeDialog>(Localizer["Create"]);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            _snackBar.Add(string.Format(Localizer["Wallet added successfully!"]), Severity.Success);

            var walletId = (Guid)result.Data;

            _tableData.RemoveAll(w => w.WalletId == walletId);

            _tableData.AddRange((await _financeOperationTypeManager.GetAllTypesOfWalletAsync(walletId)).Data);
        }
    }

    #region Editing

    public async Task OnRowEditPreview(FinanceOperationDTO type)
    {
        _typeBackup = new()
        {
            Name = type.Name,
            Description = type.Description,
            EntryType = type.EntryType,
            Id = type.Id,
            WalletId = type.WalletId,
            WalletName = type.WalletName,
        };
    }

    public async Task OnRowEditCommit(FinanceOperationDTO type)
    {
        if (type.WalletName != _typeBackup.WalletName)
            type.WalletId = Wallets.First(w => w.Name == type.WalletName).Id;

        var result = await _financeOperationTypeManager.UpdateTypeAsync(
                        _mapper.Map<UpdateFinanceOperationTypeCommand>(type));

        if (!result.Succeeded)
        {
            await OnRowEditCancel(type);
        }

        _snackBar.Add(Localizer["Financial type updated successfully!"], Severity.Success);
    }

    public async Task OnRowEditCancel(FinanceOperationDTO type)
    {
        type.WalletId = _typeBackup.WalletId;
        type.WalletName = _typeBackup.WalletName;
        type.Name = _typeBackup.Name;
        type.EntryType = _typeBackup.EntryType;
        type.Description = _typeBackup.Description;

        _snackBar.Add(Localizer["Updating canceled"], Severity.Warning);
    }

    public async Task DeleteItem(FinanceOperationTypeDTO type)
    {
        bool confirm = await _dialogService.ShowMessageBox(
            Localizer["Warning"],
            Localizer["Are you realy want to delete this financial type?"],
            yesText: Localizer["Delete!"], cancelText: Localizer["Cancel"]) ?? false;

        if (!confirm)
            return;

        var result = await _financeOperationTypeManager.DeleteTypeAsync(type.Id);

        if (!result.Succeeded)
        {
            _snackBar.Add(Localizer["Deleting failed"], Severity.Error);
            return;
        }

        _tableData.Remove(type);

        TableData.Items = _tableData;

        _snackBar.Add(Localizer["Deleting successfully"], Severity.Success);
    }
    #endregion
}
