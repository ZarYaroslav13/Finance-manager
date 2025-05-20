using FinanceManager.Application.Models.Base;

namespace FinanceManager.Application.Tests.Data.Models;

public static class HumantDTOTestDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(){ Id = 1, FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 1, FirstName = "FirstName", Email = "Email", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Password = "Password"},
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(){ Id = 1, FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 1, FirstName = "FirstName", Email = "Email", Password = "Password"}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 2, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(){ Id = 1, FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(),
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"}
        },
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO()
        },
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            null
        },
        new object[]
        {
            new UserDTO(){ Id = 1, LastName = "LastName", FirstName = "FirstName", Email = "Email", Password = "Password"},
            new ModelDTO()
        }
    };
}
