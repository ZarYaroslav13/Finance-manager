using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.Tests.Data.Models.Base;

namespace FinanceManager.Infrastructure.Tests.Models.Base;

[TestClass]
public class UserTests
{
    [TestMethod]
    [DynamicData(nameof(UserTestDataProvider.EqualsSamePropertiesReturnsTrueTestData), typeof(UserTestDataProvider))]
    public void Equals_SameProperties_ReturnsTrue(FinanceManagerUser FinanceManagerUser1, FinanceManagerUser FinanceManagerUser2)
    {
        Assert.AreEqual(FinanceManagerUser1, FinanceManagerUser2);
    }

    [TestMethod]
    [DynamicData(nameof(UserTestDataProvider.EqualsDifferentPropertiesReturnsFalseTestData), typeof(UserTestDataProvider))]
    public void Equals_DifferentProperities_ReturnsFalse(FinanceManagerUser FinanceManagerUser1, FinanceManagerUser FinanceManagerUser2)
    {
        Assert.AreNotEqual(FinanceManagerUser1, FinanceManagerUser2);
    }

    [TestMethod]
    [DynamicData(nameof(UserTestDataProvider.EqualsSamePropertiesReturnsTrueTestData), typeof(UserTestDataProvider))]
    public void GetHashCode_SameProperties_ReturnsSameHashCode(FinanceManagerUser FinanceManagerUser1, FinanceManagerUser FinanceManagerUser2)
    {
        var hashCode1 = FinanceManagerUser1.GetHashCode();
        var hashCode2 = FinanceManagerUser2.GetHashCode();

        Assert.AreEqual(hashCode1, hashCode2);
    }
}

