using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Xelit3.Playground.SignalR.Hubs;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IHubContext<UserCounterHub> _userHubContext;

    public UsersController(IUserService userService, IHubContext<UserCounterHub> userHubContext)
    {
        _userService = userService;
        _userHubContext = userHubContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();

        return Ok(users);
    }

    [HttpPost("{userId}/new-click")]
    public async Task<IActionResult> Click(int userId)
    {
        
        
        _userService.Click(userId);
        var viewModel = _userService.Get(userId);

        await _userHubContext.Clients.All.SendAsync("UserClickReceived", viewModel);
        await _userHubContext.Clients.All.SendAsync("UserClickReceived", viewModel);

        return Ok();
    }
}
