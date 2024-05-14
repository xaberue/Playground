using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SignalR.Shared.Models;

namespace Xelit3.Playground.SignalR.Services;


public interface IUserService
{
    void Click(int userId);
    UserViewModel Get(int userId);
    List<UserViewModel> GetAll();
}


public class UserService : IUserService
{

    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;


    private Dictionary<int, UserViewModel> _users =new Dictionary<int, UserViewModel>();


    public UserService(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public void Click(int userId)
    {
        _users[userId].Counter++;
    }

    public UserViewModel Get(int userId)
    {
        TryLoadIfEmpty();

        return _users[userId];
    }

    public List<UserViewModel> GetAll()
    {
        TryLoadIfEmpty();

        return [.. _users.Values];
    }

    private void TryLoadIfEmpty()
    {
        if (!_users.Any())
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var tempIndex = 1;
                _users = dbContext.Users.ToDictionary(x => tempIndex, y => new UserViewModel(tempIndex++, y.Email!));
            }
        }
    }

}
