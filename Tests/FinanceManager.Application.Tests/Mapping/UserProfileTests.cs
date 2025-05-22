using AutoMapper;
using FinanceManager.Application.Mapping;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Tests.Data.Mapping;
using FinanceManager.Application.Tests.TestToolExtensions;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Tests.Mapping;

[TestClass]
public class UserProfileTests
{
    private readonly IMapper _mapper;

    public UserProfileTests()
    {
        _mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<WalletProfile>();
                    cfg.AddProfile<FinanceOperationTypeProfile>();
                    cfg.AddProfile<FinanceOperationProfile>();
                })
            .CreateMapper();
    }

    [TestMethod]
    [DynamicData(nameof(AccountProfileTestDataProvider.DomainAccount), typeof(AccountProfileTestDataProvider))]
    public void Map_AccountDataMappedCorrectly_AccountModels(UserModel domainAccount)
    {
        var appAccount = _mapper.Map<UserDTO>(domainAccount);

        Assert.That.AreEqual(domainAccount, appAccount);
    }

    [TestMethod]
    [DynamicData(nameof(AccountProfileTestDataProvider.DomainAccount), typeof(AccountProfileTestDataProvider))]
    public void Map_AccountDataAreNotLostAfterMapping_AccountModels(UserModel domainAccount)
    {
        var mappeddomainAccount = _mapper
            .Map<UserModel>(
                _mapper
                    .Map<UserDTO>(domainAccount));

        Assert.AreEqual(domainAccount, mappeddomainAccount);
    }
}
