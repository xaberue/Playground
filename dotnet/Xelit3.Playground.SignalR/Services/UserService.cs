using Xelit3.Playground.SignalR.Models;

namespace Xelit3.Playground.SignalR.Services;


public interface IUserService
{
    void Click(int userId);
    UserViewModel Get(int userId);
    List<UserViewModel> GetAll();
}


public class UserService : IUserService
{

    private Dictionary<int, UserViewModel> _users =
        new Dictionary<int, UserViewModel>()
        {
            [1] = new UserViewModel(1, "email1@test.com"),
            [2] = new UserViewModel(2, "email2@test.com"),
            [3] = new UserViewModel(3, "email3@test.com"),
            [4] = new UserViewModel(4, "email4@test.com")
        };

    public void Click(int userId)
    {
        _users[userId].Counter++;
    }

    public UserViewModel Get(int userId)
    {
        return _users[userId];
    }

    public List<UserViewModel> GetAll()
    {
        return [.. _users.Values];
    }

}
