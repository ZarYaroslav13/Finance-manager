using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
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

    #region DailyReport
    public CreateDailyReportCommand DailyReportRequestModel { get; set; } = new();
    #endregion


    #region PeriodReport
    public CreatePeriodReportCommand PeriodReportRequestModel { get; set; } = new();
    #endregion

    private readonly IWalletManager _walletManager;
    private readonly IFinanceReportManager _financeReportManager;
    public ReportCreatorViewModel(ViewModelServicesLocator locator, IStringLocalizer<ReportsCreator> localizer) : base(locator, localizer)
    {
    }
}
