namespace FinanceManager.Infrastructure.Tests.Data;

//public static class RepositoryDataProvider
//{
//    static RepositoryDataProvider()
//    {
//        _orderedFinanceManagerUserListForGetAll
//            .ForEach(
//                a => a.Wallets = EntitiesTestDataProvider.Wallets
//                    .Where(
//                        w => w.AccountId == a.Id)
//                    .ToList());

//        _FinanceManagerUsersWithIdMoreThen3ListForGetAll.ForEach(a => a.Wallets = null);
//    }

//    private static List<FinanceManagerUser> _orderedFinanceManagerUserListForGetAll = new(
//        EntitiesTestDataProvider.FinanceManagerUsers
//            .OrderBy(a => a.LastName)
//            .Select(a => new FinanceManagerUser()
//            {
//                Id = a.Id,
//                LastName = a.LastName,
//                FirstName = a.FirstName,
//                Email = a.Email,
//                Password = a.Password
//            })
//            .ToList());

//    public static IEnumerable<object[]> OrderedFinanceManagerUserListForGetAll { get; } = new List<object[]>()
//    {
//        new object[]
//        {
//            _orderedFinanceManagerUserListForGetAll
//        }
//    };

//    private static List<FinanceManagerUser> _FinanceManagerUsersWithIdMoreThen3ListForGetAll = new(
//        EntitiesTestDataProvider.FinanceManagerUsers
//            .Where(a => a.Id > 3)
//            .Select(a => new FinanceManagerUser()
//            {
//                Id = a.Id,
//                LastName = a.LastName,
//                FirstName = a.FirstName,
//                Email = a.Email,
//                Password = a.Password
//            }).ToList());

//    public static IEnumerable<object[]> FinanceManagerUsersWithIdMoreThen3ListForGetAll { get; } = new List<object[]>()
//    {
//        new object[]
//        {
//            _FinanceManagerUsersWithIdMoreThen3ListForGetAll
//        }
//    };

//    public static IEnumerable<object[]> FinanceManagerUserWithIdEqual2ForGetById { get; } = new List<object[]>()
//    {
//        new object[]
//        {
//            EntitiesTestDataProvider.FinanceManagerUsers.FirstOrDefault(a => a.Id == 2)
//        }
//    };

//    public static IEnumerable<object[]> GetAllIntArgumentsAreLessThenZeroTestData { get; } = new List<object[]>
//    {
//        new object[]
//        {
//            0, -1
//        },
//        new object[]
//        {
//            -1, 0
//        },
//        new object[]
//        {
//            -1, -1
//        },
//    };

//    public static IEnumerable<object[]> GetAllWithSkipAndTakeTestData { get; } = new List<object[]>
//    {
//        new object[]
//        {
//            EntitiesTestDataProvider.FinanceManagerUsers,
//            EntitiesTestDataProvider.FinanceManagerUsers.GetRange(0, 3),
//            0,
//            3
//        },
//        new object[]
//        {
//            EntitiesTestDataProvider.FinanceManagerUsers,
//            EntitiesTestDataProvider.FinanceManagerUsers.GetRange(1, 3),
//            1,
//            3
//        },
//        new object[]
//        {
//            EntitiesTestDataProvider.FinanceManagerUsers,
//            EntitiesTestDataProvider.FinanceManagerUsers.GetRange(3, 2),
//            3,
//            2
//        }
//    };
//}
