using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModel_AddedGetPersonsStoreProcedure : Migration
    {
        private const string SP_NAME = "GetPersons";


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @$"
                CREATE OR ALTER PROC {SP_NAME}(@rows INT) 
                AS 
                SELECT 
	                [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
                FROM [dbo].[Persons_Guid] WITH(NOLOCK)
				ORDER BY [Id]
				OFFSET 0 ROWS
				FETCH NEXT @rows ROWS ONLY
            ";

            migrationBuilder.Sql(storedProcedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropStoredProcedure = $"DROP PROC {SP_NAME}";

            migrationBuilder.Sql(dropStoredProcedure);
        }
    }
}
