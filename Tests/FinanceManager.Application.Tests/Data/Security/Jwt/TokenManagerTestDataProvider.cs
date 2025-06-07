using AutoMapper;
using FakeItEasy;
using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Configurations;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Accounts;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FinanceManager.Application.Tests.Data.Security.Jwt;

public static class TokenManagerTestDataProvider
{
    public static IEnumerable<object[]> ConstructorArgumentsAreNullThrowsArgumentNullExceptionTestData { get; } = new List<object[]>
    {
        new object[] { A.Fake<IOptions<AuthConfiguration>>(), null, null, null},
        new object[] { A.Fake<IOptions<AuthConfiguration>>(), A.Fake<IAccountService>(), null, A.Fake<IMapper>()},
        new object[] { A.Fake<IOptions<AuthConfiguration>>(), A.Fake<IAccountService>(), null, null},
        new object[] { A.Fake<IOptions<AuthConfiguration>>(), null, null, A.Fake<IMapper>()},
        new object[] { null, null, null, null},
        new object[] { null, A.Fake<IAccountService>(), null, A.Fake<IMapper>()},
        new object[] { null, A.Fake<IAccountService>(), null, null},
        new object[] { null, null, null, A.Fake<IMapper>()},
    };

    public static IEnumerable<object[]> GetIdentityAsyncNullOrEmptyEmailOrPasswordThrowsArgumentNullExceptionTestData { get; } = new List<object[]>
    {
        new object[]{ null, "password" },
        new object[]{ "email@example.com", null },
        new object[]{ null, null },
        new object[]{ "", "password" },
        new object[]{ "email@example.com", "" },
        new object[]{ "", "" },
        new object[]{ " ", "password" },
        new object[]{ "email@example.com", " " },
        new object[]{ " ", " " }
    };

    public static IEnumerable<object[]> GetAccountIdentityAsyncValidCredentialsReturnsClaimsIdentityTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel()
            {
                Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email@gmail.com"
            },
            new ClaimsIdentity(new List<Claim>
            {
                new(nameof(UserDTO.Id), "1"),
                new(ClaimsIdentity.DefaultNameClaimType, "Email@gmail.com"),
                new(ClaimsIdentity.DefaultRoleClaimType, PolicyManager.CommonUserRole)
            }, "Token",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType)
        }
    };
}
