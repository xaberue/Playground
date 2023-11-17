﻿using System.ComponentModel.DataAnnotations;
using Xelit3.Playground.Users.Shared.Enums;

namespace Xelit3.Playground.Users.Shared.Models;


public record UserDto(int Id, string Name, string Surname, string Email, DateTime BirthDate, RoleType Role);


public record CreateUserDto 
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Surname{ get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email{ get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public DateTime BirthDate { get; set; }
}


public record UpdateUserDto(int Id, string Name, string Surname, string Email, DateTime BirthDate);