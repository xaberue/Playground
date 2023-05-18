using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModel_AddedPersonsSimpleView : Migration
    {
        private const string VIEW_NAME = "PersonsSimpleView";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var view = @$"
                CREATE VIEW {VIEW_NAME}
                AS
                SELECT 
	                [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
                FROM [dbo].[Persons_Guid]
            ";

            migrationBuilder.Sql(view);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropView = $"DROP VIEW {VIEW_NAME}";

            migrationBuilder.Sql(dropView);
        }
    }
}
