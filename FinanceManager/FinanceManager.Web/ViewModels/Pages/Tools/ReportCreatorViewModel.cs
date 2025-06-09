using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Web.Extentions;
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
        ShowReport = true;
    }
    #endregion

    #region PeriodReport
    public CreatePeriodReportCommand PeriodReportRequestModel { get; set; } = new();
    #endregion

    #region Report
    public FinanceReportDTO Report { get; set; }
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
}
