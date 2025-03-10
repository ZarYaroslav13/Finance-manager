using FakeItEasy;
using FinanceManager.ApiService.Controllers;
using MediatR;

namespace FinanceManager.ApiService.Tests.Controllers.Base;

[TestClass]
public class BaseControllerTests
{
    private readonly IMediator _mediator;
    private readonly AccountController _controller;

    public BaseControllerTests()
    {
        _mediator = A.Fake<IMediator>();

        _controller = new(_mediator);
    }

    [TestMethod]
    public void Constructor_ArgumentIsEqualNull_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new AccountController(null));
    }
}
