using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xelit3.Playground.SignalR.Models;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Controllers;


public class HomeController : Controller
{
    
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;


    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        var users = _userService.GetAll();

        return View(users);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
