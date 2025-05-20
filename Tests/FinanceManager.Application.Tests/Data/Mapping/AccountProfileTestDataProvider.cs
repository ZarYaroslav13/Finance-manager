namespace FinanceManager.Application.Tests.Data.Mapping;

public static class AccountProfileTestDataProvider
{
    public static IEnumerable<object[]> DomainAccount { get; } = new List<object[]>
    {
        new object[]
        {
            new AccountModel
            {
                Id = 2,
                LastName = "LastName",
                FirstName = "FirstName",
                Email = "email@gmail.com",
                Password = "password"
            }
        }
    };
}
