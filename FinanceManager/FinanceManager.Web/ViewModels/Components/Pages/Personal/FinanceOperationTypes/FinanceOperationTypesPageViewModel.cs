using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Web.Components.Pages.Personal.FinanceOperationTypes;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Pages;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationsType;
using FinanceManager.Web.Shared.Dialogs.FinancialOperationTypes;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Personal.FinanceOperationTypes;

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
    private FinanceOperationTypeDTO _typeBackup { get; set; }

    public Guid NewWalletId { get; set; }
    #endregion

    private readonly IFinanceOperationsTypesManager _financeOperationTypeManager;

    public FinanceOperationTypesPageViewModel(IFinanceOperationsTypesManager financeOperationTypeManager,
        ViewModelServicesLocator locator, IStringLocalizer<FinanceOperationTypesPage> localizer) : base(locator, localizer)
    {
        _financeOperationTypeManager = financeOperationTypeManager ?? throw new ArgumentNullException(nameof(financeOperationTypeManager));

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

    public async Task OnInitializedAsync(Action stateChanged)
    {
        StateHasChanged = stateChanged ?? throw new ArgumentNullException(nameof(stateChanged));

        _tableData = new();

        var getTypesReport = await _financeOperationTypeManager.GetAllTypesOfUserAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

        if (!getTypesReport.Succeeded)
        {
            _snackBar.Add("Something wrong, we can not find your finance operation types", Severity.Error);
            return;
        }

        _tableData = getTypesReport.Data;

        Wallets = _tableData
            .GroupBy(fot => fot.WalletId)
            .Select(group =>
                        new WalletDTO() { Id = group.First().WalletId, Name = group.First().WalletName })
            .ToList();

        if (WalletId != Guid.Empty)
        {
            TableData.Items = _tableData.Where(t => t.WalletId == WalletId);
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
            _snackBar.Add(Localizer["Financial type added successfully!"], MudBlazor.Severity.Success);

            var type = (FinanceOperationTypeDTO)result.Data;

            _tableData.Add(type);
        }
    }

    public async Task OnRowEditPreview(FinanceOperationTypeDTO type)
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

        NewWalletId = type.WalletId;
    }

    public async Task OnRowEditCommit(FinanceOperationTypeDTO type)
    {
        if (NewWalletId != _typeBackup.WalletId)
        {
            type.WalletId = NewWalletId;
            type.WalletName = Wallets.First(w => w.Id == type.WalletId).Name;
        }

        var result = await _financeOperationTypeManager.UpdateTypeAsync(
                        _mapper.Map<UpdateFinanceOperationTypeRequest>(type));

        if (!result.Succeeded)
        {
            await OnRowEditCancel(type);
        }

        result.Data.WalletName = type.WalletName;
        var index = _tableData.FindIndex(t => t.Id == result.Data.Id);
        _tableData[index] = result.Data;
        StateHasChanged();

        _snackBar.Add(Localizer["Financial type updated successfully!"], Severity.Success);
    }

    public async Task OnRowEditCancel(FinanceOperationTypeDTO type)
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

    public void ItemClicked(TableRowClickEventArgs<FinanceOperationTypeDTO> args)
    {
        if (args.MouseEventArgs.Detail == 2)
        {
            var type = args.Item;

            _navigationManager.NavigateTo(PagesHref.Personal.FinanceOperation.FinanceOperations + '/' + type.Id);
        }
    }
}
