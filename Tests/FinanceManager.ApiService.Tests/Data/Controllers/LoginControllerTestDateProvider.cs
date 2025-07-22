using FakeItEasy;

namespace FinanceManager.ApiService.Tests.Data.Controllers;

public static class LoginControllerTestDateProvider
{
    public static IEnumerable<object[]> ConstructorArgumentIsEqualNullThrowsArgumentNullExceptionTestData { get; } = new List<object[]>()
    {
        new object[] { A.Fake<IAccountService>(), A.Fake<ITokenService>() },
        new object[] { A.Fake<IAccountService>(), null },
        new object[] { null, A.Fake<ITokenService>() },
        new object[] { null, null },
    };

    public static IEnumerable<object[]> SignInAsyncInvalidCredentialReturnsBadRequestTestData { get; } = new List<object[]>()
    {
        new object[] { "test@example.com", "invalidpassword"}
    };

    public static IEnumerable<object[]> SignInAsyncNullOrEmptyCredentialsReturnsBadRequestTestData { get; } = new List<object[]>()
    {
        new object[] { "test@example.com", ""},
        new object[] { "test@example.com", " "},
        new object[] { "test@example.com", null},
        new object[] { "", "password"},
        new object[] { " ", "password"},
        new object[] { null, "password"},
        new object[] { "", ""},
        new object[] { "", " "},
        new object[] { "", null},
        new object[] { " ", ""},
        new object[] { null, ""},
        new object[] { " ", " "},
        new object[] { " ", null},
        new object[] { null, " "},
        new object[] { null, null},
    };
}
