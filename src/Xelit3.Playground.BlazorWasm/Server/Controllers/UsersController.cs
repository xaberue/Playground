using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.Server.Controllers
{
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
        public IEnumerable<UserDto> GetAll()
        {
            var users = _dbContext.Persons_Guid
                .Include(x => x.Origin)
                .ToList();

            return users
                .Select(x => new UserDto(x.Id, $"{x.Name} {x.Surname}", x.Origin?.Name ?? "Unknown", x.BirthDate));
        }
    }
}