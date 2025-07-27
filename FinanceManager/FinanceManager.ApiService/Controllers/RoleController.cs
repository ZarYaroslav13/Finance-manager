using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.Roles.Commands;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Services.Roles;
using FinanceManager.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

[Authorize(Policy = PolicyManager.AdminPolicy)]
public class RoleController : BaseController
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService, IMediator mediator) : base(mediator)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    /// <summary>
    /// Get All Roles (basic, admin etc.)
    /// </summary>
    /// <returns>Status 200 OK</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteRequet(async () => await _roleService.GetAllAsync());
    }

    /// <summary>
    /// Get All Roles (basic, admin etc.)
    /// </summary>
    /// <returns>Status 200 OK</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAll(Guid id)
    {
        return await ExecuteRequet(async () => await _roleService.GetByIdAsync(id));
    }

    /// <summary>
    /// Add a Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequest request)
    {
        return await ExecuteRequet(async () => await _roleService.AddAsync(request));
    }

    /// <summary>
    /// Add a Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRolesRequest request)
    {
        return await ExecuteRequet(async () => await _roleService.UpdateAsync(request));
    }

    /// <summary>
    /// Delete a Role
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status 200 OK</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await ExecuteRequet(async () => await _roleService.DeleteAsync(id));
    }
}
