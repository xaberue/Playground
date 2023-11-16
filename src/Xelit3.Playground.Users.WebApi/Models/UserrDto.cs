using Xelit3.Playground.Users.WebApi.Enums;

namespace Xelit3.Playground.Users.WebApi.Models;


public record UserDto(int Id, string Name, string Surname, string Email, DateTime BirthDate, RoleType Role);


public record CreateUserDto(string Name, string Surname, string Email, string Password, DateTime BirthDate);


public record UpdateUserDto(int Id, string Name, string Surname, string Email, DateTime BirthDate);

