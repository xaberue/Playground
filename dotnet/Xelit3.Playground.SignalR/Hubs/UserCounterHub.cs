using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Hubs;

[Authorize]
public class UserCounterHub : Hub
{

    private readonly IUserService _userService;
    private readonly IUserIdProvider _userIdProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public UserCounterHub(IUserService userService, IUserIdProvider userIdProvider, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _userIdProvider = userIdProvider;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task NotifyClick(int userId)
    {
        _userService.Click(userId);
        var viewModel = _userService.Get(userId);

        var groupName = $"userId-{userId}";
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //Notify to every connection in the groupc except the one invoking
        await Clients.OthersInGroup(groupName).SendAsync("UserClickAlreadyReceived", viewModel);
       
        //Notify to all users
        await Clients.All.SendAsync("UserClickReceived", viewModel);


        var userName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        await Clients.User(userName).SendAsync("UserMessageReceived", $"Notification only for user {userName}");
    }

}
