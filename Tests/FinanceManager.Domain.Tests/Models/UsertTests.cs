using FinanceManager.Domain.Models;
using FinanceManager.Domain.Tests.Data.Models;

namespace FinanceManager.Domain.Tests.Models;

[TestClass]
public class UsertTests
{
    [TestMethod]
    [DynamicData(nameof(AccountDataProvider.MethodEqualsResultTrueData), typeof(AccountDataProvider))]
    public void Equals_AccountModelsAreEqual_True(UserModel ac1, UserModel ac2)
    {
        Assert.AreEqual(ac1, ac2);
    }

    [TestMethod]
    [DynamicData(nameof(AccountDataProvider.MethodEqualsResultFalseData), typeof(AccountDataProvider))]
    public void Equals_AccountModelsAreNotEqual_False(UserModel ac1, object ac2)
    {
        Assert.AreNotEqual(ac1, ac2);
    }

    [TestMethod]
    [DynamicData(nameof(AccountDataProvider.MethodEqualsResultTrueData), typeof(AccountDataProvider))]
    public void GetHashCode_SameValues_ReturnsSameHashCode(UserModel account1, UserModel account2)
    {
        var hash1 = account1.GetHashCode();
        var hash2 = account2.GetHashCode();

        Assert.AreEqual(hash1, hash2);
    }
}
