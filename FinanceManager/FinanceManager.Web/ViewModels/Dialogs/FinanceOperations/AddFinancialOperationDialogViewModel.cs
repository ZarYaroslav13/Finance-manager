using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperations;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationsType;
using FinanceManager.Web.Shared.Dialogs.FinancialOperations;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Dialogs.FinanceOperations;

public class AddFinancialOperationDialogViewModel : BaseViewModel<AddFinancialOperationDialog>
{
    private AddFinanceOperationCommand _createModel = new();
    public AddFinanceOperationCommand CreationModel
    {
        get => _createModel;
        set { _createModel = value; EditContext = new(_createModel); WalletName = _types.First(t => t.Id == _createModel.TypeId).WalletName; }
    }

    private DateTime? _operationDate = DateTime.Now;
    public DateTime? OperationDate
    {
        get => _operationDate;
        set
        {
            _operationDate = value.Value.Date.Add(_operationDate.Value.TimeOfDay);
        }
    }

    private TimeSpan? _operationTime;
    public TimeSpan? OperationTime
    {
        get => _operationTime;
        set
        {
            _operationTime = value;
            TimeSpan time = _operationTime ?? TimeSpan.MinValue;
            _operationDate = _operationDate.Value.Date.Add(time);
        }
    }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    public bool Adding { get; set; } = false;

    private string _walletName = string.Empty;
    public string WalletName
    {
        get => _walletName;
        set
        {
            if (value == _walletName) return;
            _walletName = value;
            _availableTypes = _types.Where(t => string.IsNullOrWhiteSpace(_walletName) ? true : t.WalletName == _walletName).ToList();
        }
    }

    private List<FinanceOperationTypeDTO> _types = new();
    public List<FinanceOperationTypeDTO> Types { get => _types; }

    private List<FinanceOperationTypeDTO> _availableTypes = new();
    public List<FinanceOperationTypeDTO> AvailableTypes
    {
        get => _availableTypes;
        set => _availableTypes = value;
    }

    private readonly IFinanceOperationsTypesManager _typesManager;
    private readonly IFinanceOperationsManager _operationManager;

    public AddFinancialOperationDialogViewModel(IFinanceOperationsManager operationManager, IFinanceOperationsTypesManager typeManager,
        ViewModelServicesLocator locator, IStringLocalizer<AddFinancialOperationDialog> localizer) : base(locator, localizer)
    {
        _operationManager = operationManager ?? throw new ArgumentNullException(nameof(operationManager));
        _typesManager = typeManager ?? throw new ArgumentNullException(nameof(typeManager));

        EditContext = new(_createModel);
    }

    public async Task OnInitializedAsync()
    {
        var result = await _typesManager.GetAllTypesOfUserAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));
        _types = result.Data;
        _availableTypes = _types;
    }

    public async Task<FinanceOperationDTO> TryToCreate()
    {
        Adding = true;

        CreationModel.Date = OperationDate ?? DateTime.Now;

        var result = await _operationManager.AddOperationAsync(CreationModel);

        Adding = false;

        return result.Data;
    }
}