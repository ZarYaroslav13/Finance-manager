using FinanceManager.Domain.Models;
using FinanceManager.Domain.Tests.Data.Models.Base;

namespace FinanceManager.Domain.Tests.Models.Base;

[TestClass]
public class HumanModelTests
{
    [TestMethod]
    [DynamicData(nameof(UserModelTestsDataProvider.EqualsSameValuesReturnsTrueTestData), typeof(UserModelTestsDataProvider))]
    public void Equals_SameValues_ReturnsTrue(UserModel human1, UserModel human2)
    {
        Assert.AreEqual(human1, human2);
    }

    [TestMethod]
    [DynamicData(nameof(UserModelTestsDataProvider.EqualsDifferentValuesReturnsFalseTestData), typeof(UserModelTestsDataProvider))]
    public void Equals_DifferentValues_ReturnsFalse(UserModel human1, object human2)
    {
        Assert.AreNotEqual(human1, human2);
    }

    [TestMethod]
    [DynamicData(nameof(UserModelTestsDataProvider.EqualsSameValuesReturnsTrueTestData), typeof(UserModelTestsDataProvider))]
    public void GetHashCode_SameValues_ReturnsSameHashCode(UserModel human1, UserModel human2)
    {
        var hash1 = human1.GetHashCode();
        var hash2 = human2.GetHashCode();

        Assert.AreEqual(hash1, hash2);
    }
}
