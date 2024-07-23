namespace Xelit3.Playground.SignalR.Shared.Models;


public record UserViewModel(int Id, string Email)
{
    public int Counter { get; set; } = 0;
}