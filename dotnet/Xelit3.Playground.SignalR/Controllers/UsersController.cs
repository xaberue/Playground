﻿using Microsoft.AspNetCore.Mvc;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Controllers;


[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();

        return Ok(users);
    }

    [HttpPost("{userId}/new-click")]
    public IActionResult Click(int userId)
    {
        _userService.Click(userId);

        return Ok();
    }
}
