namespace Xelit3.Playground.CodingStyle;


public class User { }

public record UserDto { }

public record UserCreationParams { }


public interface IUserService
{

}

public class UserController
{

    /*
     * Option 1: Using underscore
     * Option 2: Using this
     * Option 3: Using a property
     */

    private readonly IUserService _userService;

    private readonly IUserService userService;
    private IUserService UserService { get; set; }


    public UserController(IUserService userService)
    {
        _userService = userService;

        this.userService = userService;        
        
        UserService = userService;
    }


    public void Create(UserCreationParams userCreationParams)
    {
        //Implementation goes here
    }

}