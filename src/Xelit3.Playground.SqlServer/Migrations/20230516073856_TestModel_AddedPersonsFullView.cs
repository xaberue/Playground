using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModel_AddedPersonsFullView : Migration
    {

        private const string VIEW_NAME = "PersonsFullView";


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var view = @$"
                CREATE VIEW {VIEW_NAME}
                AS
                SELECT 
	                persons.[Id] as [PersonId], persons.[OriginId], persons.[Name], persons.[Surname], persons.[BirthDate], persons.[Bio], persons.[Email], persons.[PhoneNumber],
	                addresses.[Id] as [AddressId], addresses.[CityId], addresses.[Line], addresses.[Sequence],
	                posts.[Id] as [PostId], posts.[Text], posts.[Title]
                FROM [dbo].[Persons_Guid] persons
	                join [dbo].[Addresses_Guid] addresses on persons.Id = addresses.PersonId
	                join [dbo].[Posts_Guid] posts on persons.Id = posts.AuthorId
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
