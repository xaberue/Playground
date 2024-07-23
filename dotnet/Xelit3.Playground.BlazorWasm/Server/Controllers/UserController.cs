using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly EFTestDataContext _dbContext;


    public UserController(EFTestDataContext eFTestDataContext)
    {
        _dbContext = eFTestDataContext;
    }


    [HttpGet]
    public ActionResult<IAsyncEnumerable<UserDto>> GetAll()
    {
        var users = _dbContext.Persons
            .Select(x => new UserDto(x.Id, $"{x.Name} {x.Surname}", x.Origin.Name ?? "Unknown", x.BirthDate))
            .AsAsyncEnumerable();

        return Ok(users);
    }

    [HttpGet("paginated")]
    public ActionResult<IAsyncEnumerable<UserDto>> GetAll(int page, int size)
    {
        var users = _dbContext.Persons
            .OrderBy(x => x.Name)
            .Skip(size * page).Take(size)
            .Select(x => new UserDto(x.Id, $"{x.Name} {x.Surname}", x.Origin.Name ?? "Unknown", x.BirthDate))
            .AsAsyncEnumerable();

        return Ok(users);
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