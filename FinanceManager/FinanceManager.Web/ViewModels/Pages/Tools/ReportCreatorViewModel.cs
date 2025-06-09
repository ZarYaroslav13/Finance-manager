using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Helpers;
using FinanceManager.Web.Pages.Personal;
using FinanceManager.Web.Pages.Tools;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Pages.Tools.ReportCreator;

public class ReportCreatorViewModel : BaseViewModel<ReportsCreator>
{
    #region Selection
    public List<FinancialReportVariant> ReportVariants { get; set; } = new(typeof(FinancialReportVariant).GetEnumValues().Cast<FinancialReportVariant>());

    public FinancialReportVariant SelectedReportVariant { get; set; }
    #endregion

    public bool ShowReport { get; set; } = false;

    public List<WalletDTO> Wallets { get; set; } = new();

    #region DailyReport
    public CreateDailyReportCommand DailyReportRequestModel { get; set; } = new();

    public async Task CreateDailyReport()
    {
        Report = (await _financeReportManager.CreateDailyReportAsync(DailyReportRequestModel)).Data;
        await SetChartData();
        ShowReport = true;
    }
    #endregion

    #region PeriodReport
    public CreatePeriodReportCommand PeriodReportRequestModel { get; set; } = new();
    #endregion

    #region Report
    public FinanceReportDTO Report { get; set; }

    #region Wallet balance changes chart (Mixed)

    public bool ShowWalletBalanceChangesChart { get; set; } = true;

    #endregion

    #region Entry types amount chart (Pie)

    public bool ShowEntryTypesAmountChart { get; set; } = true;

    public List<ApexChartValue<int>> EntryTypesApexValues { get; set; } = new();
    #endregion


    #region Types amount chart (Donut)

    public bool ShowTypesAmountChart { get; set; } = true;

    public List<ApexChartValue<int>> TypesApexValues { get; set; } = new();
    #endregion
    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceReportManager _financeReportManager;
    public ReportCreatorViewModel(IWalletManager walletManager, IFinanceReportManager financeReportManager,
        ViewModelServicesLocator locator, IStringLocalizer<ReportsCreator> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));
        _financeReportManager = financeReportManager ?? throw new ArgumentNullException(nameof(financeReportManager));
    }

    public async Task OnInitialized()
    {
        var result = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

        Wallets = result.Data;

        DailyReportRequestModel.Date = DateTime.Now;


        PeriodReportRequestModel.StartDate = DateTime.Now;
        PeriodReportRequestModel.EndDate = DateTime.Now;
    }

    private async Task SetChartData()
    {
        EntryTypesApexValues = new()
        {
            new() { Label="Incomes", Value=Report.TotalIncome, Color="#28a745"},
            new() { Label="Expenses", Value=Report.TotalExpense, Color="#dc3545"}
        };

        var types = FindAllTypesWithAmounts();

        SetTypesApexValues();
    }

    private Dictionary<FinanceOperationTypeDTO, int> FindAllTypesWithAmounts()
    {
        var result = new Dictionary<FinanceOperationTypeDTO, int>();
        FinanceOperationTypeDTO type = new();

        foreach(var operation in Report.Operations)
        {
            type = result.FirstOrDefault(r => r.Key.Id == operation.Type.Id).Key;
            if (type == null)
                result.Add(operation.Type, operation.Amount);
            else
                result[type] += operation.Amount;
        }

        return result;
    }

    private void SetTypesApexValues()
    {
        var types = FindAllTypesWithAmounts();
        TypesApexValues = new();

        foreach (var type in types)
        {
            TypesApexValues.Add(
                new() { 
                    Label = type.Key.Name, 
                    Value = type.Value, 
                    Color = 
                        type.Key.EntryType == Infrastructure.Models.EntryType.Income?ColorRandomizer.GetRandomGreenColor() : ColorRandomizer.GetRandomRedColor()});
        }
    }
}
