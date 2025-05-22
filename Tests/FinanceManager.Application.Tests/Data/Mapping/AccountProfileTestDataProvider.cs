using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Tests.Data.Mapping;

public static class AccountProfileTestDataProvider
{
    public static IEnumerable<object[]> DomainAccount { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel
            {
                Id = Guid.Parse("2"),
                LastName = "LastName",
                FirstName = "FirstName",
                Email = "email@gmail.com"
            }
        }
    };
}
