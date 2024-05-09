using Microsoft.AspNetCore.SignalR;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Hubs;

public class UserCounterHub : Hub
{

    private readonly IUserService _userService;


    public UserCounterHub(IUserService userService)
    {
        _userService = userService;
    }


    public async Task NotifyClick(int userId)
    {
        var viewModel = _userService.Get(userId);

        await Clients.All.SendAsync("UserClickReceived", viewModel);
    }
}
