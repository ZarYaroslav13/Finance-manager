using ApexCharts;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Web.Components.Pages.Tools;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Helpers;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Components.Pages.Tools.ReportCreator;

public class ReportCreatorViewModel : BaseViewModel<ReportsCreator>
{
    #region Selection
    public List<FinancialReportVariant> ReportVariants { get; set; } = new(typeof(FinancialReportVariant).GetEnumValues().Cast<FinancialReportVariant>());

    public FinancialReportVariant SelectedReportVariant { get; set; }
    #endregion


    public List<WalletDTO> Wallets { get; set; } = new();

    #region DailyReport
    public CreateDailyReportCommand DailyReportRequestModel { get; set; } = new();
    #endregion

    #region PeriodReport
    public CreatePeriodReportCommand PeriodReportRequestModel { get; set; } = new();
    #endregion

    #region Report

    public async Task CreateReport(FinancialReportVariant variant)
    {

        Report = await _reportRequests[variant].Invoke() ;
        await SetChartData();
        ShowReport = true;
    }

    public bool ShowReport { get; set; } = false;
    public FinanceReportDTO Report { get; set; }

    #region Opeations history chart (Mixed)

    public bool ShowOperationshistoryChart { get; set; } = true;

    public List<ApexChartValue<DateTime, int>> OperationsHistoryValues { get; set; } = new();

    public ApexChartOptions<ApexChartValue<DateTime, int>> OperationsHistoryChartOptions { get; } = new()
    {
        Yaxis = new List<YAxis>
        {
            new YAxis
            {
                Labels = new YAxisLabels
                {
                    Formatter = @"function(value) {
                        return '¤' + value.toLocaleString(); 
                    }"
                }
            }
        },
        Xaxis = new XAxis
        {
            Labels = new XAxisLabels
            {
                Formatter = @"function(value) {
                if (!value) return '';
                return value.toUpperCase(); 
            }"
            }
        },
        DataLabels = new DataLabels
        {
            Enabled = true,
            Formatter = @"function(value) {
            return value.toLocaleString(); 
        }"
        },
        Tooltip = new Tooltip
        {
            Enabled = true,
            Y = new()
            {
                Formatter = @"function(value, opts) {
        const point = opts.w.config.series[opts.seriesIndex].data[opts.dataPointIndex];
        return point.label + ': \U+oo37' + point.y + ' on ' + new Date(point.x).toLocaleDateString();
    }"
            }
        }
    };

    #endregion

    #region Entry types amount chart (Pie)

    public bool ShowEntryTypesAmountChart { get; set; } = true;

    public List<ApexChartValue<int>> EntryTypesApexValues { get; set; } = new();
    #endregion

    #region Types amount chart (Donut)

    public bool ShowTypesAmountChart { get; set; } = true;

    public List<ApexChartValue<int>> TypesApexValues { get; set; } = new();
    #endregion

    private Dictionary<FinancialReportVariant, Func<Task<FinanceReportDTO>>> _reportRequests = new();

    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceReportManager _financeReportManager;
    public ReportCreatorViewModel(IWalletManager walletManager, IFinanceReportManager financeReportManager,
        ViewModelServicesLocator locator, IStringLocalizer<ReportsCreator> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));
        _financeReportManager = financeReportManager ?? throw new ArgumentNullException(nameof(financeReportManager));

        BuildReportRequests();
    }

    public async Task OnInitialized()
    {
        var result = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

        Wallets = result.Data;

        DailyReportRequestModel.Date = DateTime.Now;


        PeriodReportRequestModel.StartDate = DateTime.Now;
        PeriodReportRequestModel.EndDate = DateTime.Now;
    }

    private void BuildReportRequests()
    {
        _reportRequests.Add(FinancialReportVariant.Daily, async () => (await _financeReportManager.CreateDailyReportAsync(DailyReportRequestModel)).Data);
        _reportRequests.Add(FinancialReportVariant.Period, async () => (await _financeReportManager.CreatePeriodReportAsync(PeriodReportRequestModel)).Data);
    }

    private async Task SetChartData()
    {
        EntryTypesApexValues = new()
        {
            new() { Label="Incomes", Value=Report.TotalIncome, Color="#28a745"},
            new() { Label="Expenses", Value=Report.TotalExpense, Color="#dc3545"}
        };

        SetOperationHistoryValues();

        SetTypesApexValues();
    }

    private void SetOperationHistoryValues()
    {
        OperationsHistoryValues = Report.Operations.Select(op => new ApexChartValue<DateTime, int>()
        {
            Label = op.Type.Name,
            ValueX = op.Date,
            ValueY = op.Amount,
            Color = op.Type.EntryType == Infrastructure.Models.EntryType.Income ? "#28a745" : "#dc3545"

        }).ToList();
    }

    private void SetTypesApexValues()
    {
        var types = FindAllTypesWithAmounts();
        TypesApexValues = new();

        foreach (var type in types)
        {
            TypesApexValues.Add(
                new()
                {
                    Label = type.Key.Name,
                    Value = type.Value,
                    Color =
                        type.Key.EntryType == Infrastructure.Models.EntryType.Income ? ColorRandomizer.GetRandomGreenColor() : ColorRandomizer.GetRandomRedColor()
                });
        }
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

}
