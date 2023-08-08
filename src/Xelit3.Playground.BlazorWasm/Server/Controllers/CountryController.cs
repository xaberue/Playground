using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{

    private readonly EFTestDataContext _dbContext;


    public CountryController(EFTestDataContext eFTestDataContext)
    {
        _dbContext = eFTestDataContext;
    }


    [HttpGet]
    public ActionResult<IAsyncEnumerable<CountryDto>> GetAll()
    {
        var countries = _dbContext.Countries
            .Select(x => new CountryDto(x.Id, x.Name))
            .AsAsyncEnumerable();

        return Ok(countries);
    }
    
}