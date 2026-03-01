using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Xelit3.Playground.Scheduling.TickerqDemo.Services;

namespace Xelit3.Playground.Scheduling.TickerqDemo;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = await _userService.RegisterUserAsync(
            request.Email,
            "TEST NAME"
        );

        return Ok(new { userId = user.Id });
    }
}