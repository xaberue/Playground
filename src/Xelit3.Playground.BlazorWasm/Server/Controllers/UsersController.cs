using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly EFTestDataContext _dbContext;


    public UsersController(EFTestDataContext eFTestDataContext)
    {
        _dbContext = eFTestDataContext;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _dbContext.Persons
            .Include(x => x.Origin)
            .ToList();

        return Ok(users
            .Select(x => new UserDto(x.Id, $"{x.Name} {x.Surname}", x.Origin?.Name ?? "Unknown", x.BirthDate)));
    }

    [HttpGet("paginated")]
    public IActionResult GetAll(int page, int size)
    {
        var users = _dbContext.Persons
            .Include(x => x.Origin)
            .OrderBy(x => x.Name)
            .Skip(size * page).Take(size)
            .ToList();

        return Ok(users
            .Select(x => new UserDto(x.Id, $"{x.Name} {x.Surname}", x.Origin?.Name ?? "Unknown", x.BirthDate)));
    }


    [HttpPost]
    public IActionResult Save(UserCreationDto userCreationDto)
    {
        var user = new Person<Guid> { OriginId = userCreationDto.OriginId, Name = userCreationDto.Name, Surname = userCreationDto.Surname, BirthDate = userCreationDto.BirthDate };

        _dbContext.Persons.Add(user);
        _dbContext.SaveChanges();

        return CreatedAtAction("Save", new UserDto(user.Id, $"{user.Name} {user.Surname}", user.Origin?.Name ?? "Unknown", user.BirthDate));
    }
}