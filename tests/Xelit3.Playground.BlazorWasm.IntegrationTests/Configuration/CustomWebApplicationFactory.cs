using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(EFTestDataContext));

            services.Remove(dbContextDescriptor);

            services.AddScoped(x => DbContextHelper.CreateDbContext());
        });

        builder.UseEnvironment("Tests");
    }

}
