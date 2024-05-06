using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Playground.Users.WebApi.Infrastructure;

namespace Xelit3.Playground.Users.Tests.Helpers;


public abstract class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>
{

    protected readonly CustomWebApplicationFactory<Program> _factory;


    protected HttpClient Client => _factory.CreateClient();


    protected IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


    protected UsersDbContext GetDbContext() => DbContextHelper.CreateDbContext();

}

