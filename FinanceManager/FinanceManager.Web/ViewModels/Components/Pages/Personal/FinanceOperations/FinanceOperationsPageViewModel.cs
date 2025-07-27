using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Web.Components.Pages.Personal.FinanceOperations;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperations;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationsType;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.FinancialOperations;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Personal.FinanceOperations;

public class FinanceOperationsPageViewModel : BaseViewModel<FinanceOperationsPage>
{
    public static class TableLabels
    {
        public const string WalletName = nameof(FinanceOperationDTO.Type.WalletName);
        public const string TypeName = nameof(FinanceOperationDTO.Type.Name);
        public const string Amount = nameof(FinanceOperationDTO.Amount);
        public const string Date = nameof(FinanceOperationDTO.Date);

        public readonly static List<string> Labels = new()
        {
            WalletName, TypeName, Amount, Date
        };
    }

    public Guid TypeId { get; set; }

    public List<WalletDTO> Wallets { get; private set; } = new();
    public List<FinanceOperationTypeDTO> FinancialOperationsTypes { get; private set; } = new();

    private List<FinanceOperationDTO> _tableData = new();
    public MudTable<FinanceOperationDTO> TableData { get; set; } = new();

    public Dictionary<string, Func<FinanceOperationDTO, object>> SortFunctions { get; } = new()
    {
        { TableLabels.WalletName, operation => operation.Type.WalletName },
        { TableLabels.TypeName, operation => operation.Type.Name },
        { TableLabels.Amount, operation => operation.Amount },
        { TableLabels.Date, operation => operation.Date }
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

    private DateTime? _filterStartDate = DateTime.Now;
    public DateTime? FilterStartDate
    {
        get => _filterStartDate;
        set
        {
            _filterStartDate = value.Value.Date.Add(_filterStartDate.Value.TimeOfDay);
            Filter();
        }
    }

    private TimeSpan? _filterStartDateTime;
    public TimeSpan? FilterStartDateTime
    {
        get => _filterStartDateTime;
        set
        {
            _filterStartDateTime = value;
            TimeSpan time = _filterStartDateTime ?? TimeSpan.MinValue;
            _filterStartDate = _filterStartDate.Value.Date.Add(time);
            Filter();
        }
    }

    private DateTime? _filterEndDate = DateTime.Now;
    public DateTime? FilterEndDate
    {
        get => _filterEndDate;
        set
        {
            _filterEndDate = value.Value.Date.Add(_filterEndDate.Value.TimeOfDay);
            Filter();
        }
    }

    private TimeSpan? _filterEndDateTime;
    public TimeSpan? FilterEndDateTime
    {
        get => _filterEndDateTime;
        set
        {
            _filterEndDateTime = value;
            TimeSpan time = _filterEndDateTime ?? TimeSpan.MinValue;
            _filterEndDate = _filterEndDate.Value.Date.Add(time);
        }
    }
    #endregion

    #region Grouping

    public TableGroupDefinition<FinanceOperationDTO> GroupDefinition { get; }

    #endregion

    #region Updating
    public DateTime? NewDate { get; set; }
    public TimeSpan? NewTime { get; set; }

    private FinanceOperationDTO _typeBackup { get; set; } = new();

    public FinanceOperationTypeDTO NewType { get; set; } = new();
    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceOperationsTypesManager _financeOperationTypeManager;
    private readonly IFinanceOperationsManager _financeOperationsManager;

    public FinanceOperationsPageViewModel(IFinanceOperationsManager financeOperationsManager, IFinanceOperationsTypesManager financeOperationTypeManager, IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<FinanceOperationsPage> localizer) : base(locator, localizer)
    {
        _financeOperationsManager = financeOperationsManager ?? throw new ArgumentNullException(nameof(financeOperationsManager));
        _financeOperationTypeManager = financeOperationTypeManager ?? throw new ArgumentNullException(nameof(financeOperationTypeManager));
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));

        GroupDefinition = new()
        {
            GroupName = Localizer["Wallet"],
            Indentation = false,
            Expandable = true,
            IsInitiallyExpanded = false,
            Selector = (e) => e.Type.WalletName,
            InnerGroup = new()
            {
                GroupName = Localizer["Type"],
                IsInitiallyExpanded = false,
                Expandable = true,
                Selector = e => e.Type.Name
            }
        };

        LocalizedTableLabels.Add(String.Empty, String.Empty);

        foreach (var item in TableLabels.Labels)
        {
            LocalizedTableLabels.Add(item, Localizer[item]);
        }
    }

    public async Task OnInitializedAsync(Action hasChanged)
    {
        StateHasChanged = hasChanged ?? throw new ArgumentNullException(nameof(hasChanged));

        _tableData = new();

        Wallets = (await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()))).Data;

        foreach (var wallet in Wallets)
        {
            var operations = await _financeOperationsManager.GetAllOperationsOfWalletAsync(new() { WalletId = wallet.Id });
            operations.Data.ForEach(d => d.Type.WalletName = wallet.Name);

            var types = operations.Data.GroupBy(op => op.Type).Select(pair => pair.Key).ToList();

            FinancialOperationsTypes.AddRange(types);

            operations.Data.ForEach(d => d.Type.WalletName = wallet.Name);
            _tableData.AddRange(operations.Data);
        }

        if (TypeId != Guid.Empty)
        {
            TableData.Items = _tableData.Where(t => t.Type.Id == TypeId);
            return;
        }

        TableData.Items = _tableData;

        _filterStartDate = _tableData.Aggregate((first, next) => first.Date > next.Date ? next : first).Date;
    }

    #region Filtering
    public void Filter()
    {
        if (((FilterValue == String.Empty) && (FilterProperty != TableLabels.Date)) || FilterProperty == String.Empty)
        {
            TableData.Items = _tableData;
            return;
        }

        TableData.Items = _tableData.Where(Filter)
            .ToList();

    }

    private bool Filter(FinanceOperationDTO operation)
    {
        switch (FilterProperty)
        {
            case TableLabels.WalletName:
                return operation.Type.WalletName.ToLower().Contains(FilterValue.ToLower());
            case TableLabels.TypeName:
                return operation.Type.Name.ToLower().Contains(FilterValue.ToLower());
            case TableLabels.Amount:
                return operation.Amount.ToString().Contains(FilterValue);
            case TableLabels.Date:
                return _filterEndDate >= operation.Date && operation.Date >= _filterStartDate;
            default:
                return true;
        }
    }
    #endregion

    public async Task CreateFinancialOperation()
    {
        var dialog = (DialogReference)await _dialogService.ShowAsync<AddFinancialOperationDialog>(Localizer["Create"]);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            _snackBar.Add(string.Format(Localizer["Operation added successfully!"]), Severity.Success);

            var operation = (FinanceOperationDTO)result.Data;

            _tableData.Add(operation);

            Filter();
        }
    }

    #region Editing

    public async Task OnRowEditPreview(FinanceOperationDTO operation)
    {
        _typeBackup = new()
        {
            Id = operation.Id,
            Amount = operation.Amount,
            Date = operation.Date,
            Type = operation.Type
        };

        NewDate = operation.Date;
        NewTime = operation.Date.TimeOfDay;

        NewType = operation.Type;
    }

    public async Task OnRowEditCommit(FinanceOperationDTO operation)
    {
        NewDate.Value.Add(NewTime.Value);
        operation.Date = NewDate ?? operation.Date;

        operation.Type = NewType;

        var result = await _financeOperationsManager.UpdateOperationAsync(
                        _mapper.Map<UpdateFinanceOperationRequest>(operation));

        if (!result.Succeeded)
        {
            await OnRowEditCancel(operation);
            return;
        }
        var index = _tableData.FindIndex(o => o.Id == operation.Id);
        _tableData[index] = result.Data;
        StateHasChanged.Invoke();

        _snackBar.Add(Localizer["Financial operation updated successfully!"], Severity.Success);
        Filter();
    }

    public async Task OnRowEditCancel(FinanceOperationDTO operation)
    {
        operation.ChangeFinanceOperationType(_typeBackup.Type);
        operation.Amount = _typeBackup.Amount;
        operation.Date = _typeBackup.Date;

        _snackBar.Add(Localizer["Updating canceled"], Severity.Warning);
    }

    public async Task DeleteItem(FinanceOperationDTO operation)
    {
        bool confirm = await _dialogService.ShowMessageBox(
            Localizer["Warning"],
            Localizer["Are you realy want to delete this financial operation?"],
            yesText: Localizer["Delete!"], cancelText: Localizer["Cancel"]) ?? false;

        if (!confirm)
            return;

        var result = await _financeOperationsManager.DeleteOperationAsync(operation.Id);

        if (!result.Succeeded)
        {
            _snackBar.Add(Localizer["Deleting failed"], Severity.Error);
            return;
        }

        _tableData.Remove(operation);

        TableData.Items = _tableData;

        _snackBar.Add(Localizer["Deleting successfully"], Severity.Success);
    }
    #endregion
}
