namespace FinanceManager.Infrastructure.Tests;

//[TestClass]
//public class RepositoryTests
//{
//    private readonly AppDbContext _context;
//    private readonly IRepository<FinanceManagerUser> _repository;

//    public RepositoryTests()
//    {
//        var options = new DbContextOptionsBuilder<AppDbContext>();

//        options.UseInMemoryDatabase("TestDbForRepository");

//        _context = new AppDbContext(options.Options);

//        _repository = new Repository<FinanceManagerUser>(_context);
//    }

//    [TestCleanup]
//    public async Task Cleanup()
//    {
//        await _context.Database.EnsureDeletedAsync();
//        await _context.DisposeAsync();
//    }

//    [TestMethod]
//    public void Constructor_DbContextIsNull_ThrowsException()
//    {
//        Assert.ThrowsException<ArgumentNullException>(() => new Repository<FinanceManagerUser>(null));
//    }

//    [TestMethod]
//    [DynamicData(nameof(RepositoryDataProvider.GetAllIntArgumentsAreLessThenZeroTestData), typeof(RepositoryDataProvider))]
//    public async Task GetAllAsync_IntArgumentsAreLessThenZero_ThrowException(int skip, int take)
//    {
//        await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _repository.GetAllAsync(take: take, skip: skip));
//    }

//    [TestMethod]
//    [DynamicData(nameof(RepositoryDataProvider.OrderedFinanceManagerUserListForGetAll), typeof(RepositoryDataProvider))]
//    public async Task GetAllAsync_FinanceManagerUsersWithWalletListIsOrderedByLastName_OrderedFinanceManagerUserListWithWallets(List<FinanceManagerUser> expectedOrderedFinanceManagerUsersList)
//    {
//        await _context.AddRangeAsync(EntitiesTestDataProvider.FinanceManagerUsers);
//        await _context.AddRangeAsync(EntitiesTestDataProvider.Wallets);
//        await _context.SaveChangesAsync();

//        var resultOrderedFinanceManagerUsersList = await _repository.GetAllAsync(includeProperties: nameof(FinanceManagerUser.Wallets),
//                                           orderBy: qa => qa.OrderBy(a => a.LastName));

//        CollectionAssert.AreEqual(expectedOrderedFinanceManagerUsersList, resultOrderedFinanceManagerUsersList.ToList());
//    }

//    [TestMethod]
//    [DynamicData(nameof(RepositoryDataProvider.FinanceManagerUsersWithIdMoreThen3ListForGetAll), typeof(RepositoryDataProvider))]
//    public async Task GetAllAsync_FinanceManagerUserListIsFilteredById_FilteredFinanceManagerUserList(List<FinanceManagerUser> expectedFilteredFinanceManagerUserList)
//    {
//        Expression<Func<FinanceManagerUser, bool>> predicate = (ac) => ac.Id > 3;

//        await _context.AddRangeAsync(EntitiesTestDataProvider.FinanceManagerUsers);
//        await _context.SaveChangesAsync();

//        var resultFilteredFinanceManagerUserList = await _repository.GetAllAsync(filter: predicate);

//        CollectionAssert.AreEqual(
//            expectedFilteredFinanceManagerUserList
//                .OrderBy(a => a.Id).ToList(),
//            resultFilteredFinanceManagerUserList
//                .OrderBy(a => a.Id).ToList());
//    }

//    [TestMethod]
//    [DynamicData(nameof(RepositoryDataProvider.GetAllWithSkipAndTakeTestData), typeof(RepositoryDataProvider))]
//    public async Task GetAllAsync_WithSkipAndTake_ReceivedExpectedFinanceManagerUserList_FinanceManagerUserList(List<FinanceManagerUser> FinanceManagerUsers, List<FinanceManagerUser> expectedFinanceManagerUserList, int skip, int take)
//    {
//        await _context.AddRangeAsync(FinanceManagerUsers);
//        await _context.SaveChangesAsync();

//        var result = await _repository.GetAllAsync(skip: skip, take: take);

//        CollectionAssert.AreEqual(expectedFinanceManagerUserList, result.ToList());
//    }

//    [TestMethod]
//    public async Task Insert_AddedNewFinanceManagerUserToDatabase_NewFinanceManagerUser()
//    {
//        var newFinanceManagerUser = new FinanceManagerUser()
//        {
//            LastName = "LastName",
//            FirstName = "FirstName",
//            Email = "Email",
//            
//        };

//        _repository.Insert(newFinanceManagerUser);
//        await _context.SaveChangesAsync();

//        var FinanceManagerUsers = await _repository.GetAllAsync();

//        Assert.IsTrue(FinanceManagerUsers.Any(a => a.Equals(newFinanceManagerUser)));
//    }

//    [TestMethod]
//    public async Task UpdateAsync_FinanceManagerUserAfterUpdatingIsChanged_UpdatedFinanceManagerUser()
//    {
//        var FinanceManagerUser = new FinanceManagerUser()
//        {
//            LastName = "LastName",
//            FirstName = "FirstName",
//            Email = "Email",
//            
//        };

//        _repository.Insert(FinanceManagerUser);
//        await _context.SaveChangesAsync();

//        FinanceManagerUser.FirstName = "New FirstName";
//        _repository.Update(FinanceManagerUser);
//        await _context.SaveChangesAsync();

//        var updatedFinanceManagerUser = (await _repository.GetAllAsync()).LastOrDefault();

//        Assert.AreEqual(FinanceManagerUser, updatedFinanceManagerUser);
//    }

//    [TestMethod]
//    public async Task Delete_FinanceManagerUserDoesNotExistInDatabase_Void()
//    {
//        await _context.AddRangeAsync(EntitiesTestDataProvider.FinanceManagerUsers);
//        await _context.SaveChangesAsync();

//        var removedFinanceManagerUser = EntitiesTestDataProvider.FinanceManagerUsers[3];

//        _repository.Delete(removedFinanceManagerUser.Id);
//        await _context.SaveChangesAsync();

//        var FinanceManagerUsers = await _repository.GetAllAsync();

//        Assert.IsFalse(FinanceManagerUsers.Contains(removedFinanceManagerUser));
//    }

//    [TestMethod]
//    [DynamicData(nameof(RepositoryDataProvider.FinanceManagerUserWithIdEqual2ForGetById), typeof(RepositoryDataProvider))]
//    public async Task GetByIdAsync_GettedFinanceManagerUserWithNeededId_FinanceManagerUser(FinanceManagerUser expectedFinanceManagerUser)
//    {
//        await _context.AddRangeAsync(EntitiesTestDataProvider.FinanceManagerUsers);
//        await _context.SaveChangesAsync();

//        var foundFinanceManagerUser = await _repository.GetByIdAsync(expectedFinanceManagerUser.Id);

//        foundFinanceManagerUser.Wallets = null;

//        Assert.AreEqual(expectedFinanceManagerUser, foundFinanceManagerUser);
//    }

//    [TestMethod]
//    public void GetByIdAsync_FinanceManagerUserWithIdDontExist_ThrowsArgumentExceptin()
//    {
//        int id = 0;

//        Assert.ThrowsExceptionAsync<ArgumentException>(() => _repository.GetByIdAsync(id));
//    }
//}
