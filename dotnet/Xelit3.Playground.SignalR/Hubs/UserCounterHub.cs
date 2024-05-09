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
        _userService.Click(userId);
        var viewModel = _userService.Get(userId);

        var groupName = $"userId-{userId}";

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.OthersInGroup(groupName).SendAsync("UserClickAlreadyReceived", viewModel);

        await Clients.All.SendAsync("UserClickReceived", viewModel);
    }
}
