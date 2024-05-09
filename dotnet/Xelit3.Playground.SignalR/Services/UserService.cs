using Xelit3.Playground.SignalR.Models;

namespace Xelit3.Playground.SignalR.Services;


public interface IUserService
{
    List<User> GetAll();
}


public class UserService : IUserService
{

    private List<User> _users = 
        [
            new User(1, "email1@test.com"),
            new User(2, "email2@test.com"),
            new User(3, "email3@test.com"),
            new User(4, "email4@test.com"),
        ];


    public List<User> GetAll()
    {
        return _users;
    }

}
