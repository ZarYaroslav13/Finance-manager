using FinanceManager.Application.Models.Base;

namespace FinanceManager.Application.Tests.Data.Models;

public static class HumantDTOTestDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"},
            new UserDTO(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName"},
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName"}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserDTO(){ Id =  Guid.Parse("2"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"},
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserDTO(),
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserDTO()
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            null
        },
        new object[]
        {
            new UserDTO(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new ModelDTO()
        }
    };
}
