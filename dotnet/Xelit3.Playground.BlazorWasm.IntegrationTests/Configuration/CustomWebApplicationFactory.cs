using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // NOTE: This is a better way to configure the application for testing purposes.
        //builder.ConfigureAppConfiguration((context, config) =>
        //{
        //    config.AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true);
        //});

        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(EFTestDataContext));

            services.Remove(dbContextDescriptor);

            services.AddScoped(x => DbContextHelper.CreateDbContext());
        });

        builder.UseEnvironment("Development");
    }

}
