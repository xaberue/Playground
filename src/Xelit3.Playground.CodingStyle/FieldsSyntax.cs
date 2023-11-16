namespace Xelit3.Playground.CodingStyle;


public class User { }

public record UserDto { }

public record UserCreationParams { }


public interface IUserService
{

}

public class UserController
{

    private readonly IUserService _userService;

    private readonly IUserService userService;

    private object? UserSomething;


    public UserController(IUserService userService)
    {
        this.userService = userService;
    }


    public void Create(UserCreationParams userCreationParams)
    {
        //Implementation goes here
    }

}