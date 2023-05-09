using Microsoft.Extensions.Configuration;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration
{
    public class DbContextHelper
    {
        private static readonly string _connectionString = string.Empty;

        static DbContextHelper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.Tests.json", optional: true)
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultDbConnectionString");
        }

        public static EFTestDataContext CreateDbContext() => new EFTestDataContext(_connectionString);
    }
}
