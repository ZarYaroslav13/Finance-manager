using FakeItEasy;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;

namespace FinanceManager.ApiService.Tests.Data.Controllers;

public static class FinanceReportControllerTestDataProvider
{
    public static IEnumerable<object[]> ConstructorArgumentsAreNullThrowsArgumentNullExceptionTestData { get; } = new List<object[]>
    {
        new object[]{ A.Dummy<IFinanceReportCreator>(), null },
        new object[]{ null, A.Dummy<IWalletService>() },
        new object[]{ null, null },
    };
}
