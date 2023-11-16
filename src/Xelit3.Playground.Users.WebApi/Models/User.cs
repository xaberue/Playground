using Xelit3.Playground.Users.WebApi.Enums;

namespace Xelit3.Playground.Users.WebApi.Models;


public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public RoleType Role { get; private set; } = RoleType.Basic;
    public DateTime BirthDate { get; private set; }

    public string FullName => $"{Name} {Surname}";


    public User(string name, string surname, string email, string password, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }


    public void ChangeRole(RoleType role)
    {
        Role = role;
    }

    public void Update(string name, string surname, string email, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthDate;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

}