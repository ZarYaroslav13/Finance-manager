using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.Tests.Data.Models.Base;

public static class UserModelTestsDataProvider
{
    public static IEnumerable<object[]> EqualsSameValuesReturnsTrueTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        }
    };

    public static IEnumerable<object[]> EqualsDifferentValuesReturnsFalseTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id = Guid.Parse("2"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Smith",
                Email = "john.doe@example.com",

            }
        },
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.smith@example.com",

            }
        },
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            null
        },
        new object[]
        {
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",

            },
            new UserModel
            {
                Id =  Guid.Parse("1"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            }
        }
    };
}
