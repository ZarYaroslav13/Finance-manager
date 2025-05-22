using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Infrastructure.Tests.Data.Models.Base;

public static class UserTestDataProvider
{
    public static IEnumerable<object[]> EqualsSamePropertiesReturnsTrueTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        }
    };

    public static IEnumerable<object[]> EqualsDifferentPropertiesReturnsFalseTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("2"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Smith",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "jane.doe@example.com",

            }
        },
        new object[]
        {
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new FinanceManagerUser
            {
                Id = Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            }
        }
    };
}
