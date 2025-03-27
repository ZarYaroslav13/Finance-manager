using FakeItEasy;
using FinanceManager.ApiService.Controllers;
using Infrastructure.Security;
using MediatR;

namespace FinanceManager.ApiService.Tests.Controllers.Base;

[TestClass]
public class BaseControllerTests
{
    private readonly IMediator _mediator;
    private readonly IPasswordCoder _passwordCoder;
    private readonly AccountController _controller;

    public BaseControllerTests()
    {
        _mediator = A.Fake<IMediator>();
        _passwordCoder = A.Fake<IPasswordCoder>();


        _controller = new(_mediator, _passwordCoder);
    }

    [TestMethod]
    public void Constructor_ArgumentIsEqualNull_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new AccountController(null, _passwordCoder));
        Assert.ThrowsException<ArgumentNullException>(() => new AccountController(_mediator, null));
        Assert.ThrowsException<ArgumentNullException>(() => new AccountController(null, null));
    }
}
