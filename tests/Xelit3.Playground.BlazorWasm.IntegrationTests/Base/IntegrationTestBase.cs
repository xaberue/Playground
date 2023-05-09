using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests.Base;

public abstract class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>
{

    protected readonly CustomWebApplicationFactory<Program> _factory;


    protected HttpClient Client => _factory.CreateClient();


    protected IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


    protected EFTestDataContext GetDbContext() => DbContextHelper.CreateDbContext();

}
