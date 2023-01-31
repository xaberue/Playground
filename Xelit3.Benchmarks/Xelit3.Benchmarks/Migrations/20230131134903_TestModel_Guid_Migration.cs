using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModelGuidMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries_Guid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_Guid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities_Guid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities_Guid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Guid_Countries_Guid_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries_Guid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons_Guid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_Guid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Guid_Countries_Guid_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Countries_Guid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses_Guid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses_Guid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Guid_Cities_Guid_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities_Guid",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Guid_Persons_Guid_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons_Guid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts_Guid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts_Guid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Guid_Persons_Guid_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons_Guid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Guid_CityId",
                table: "Addresses_Guid",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Guid_PersonId",
                table: "Addresses_Guid",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Guid_CountryId",
                table: "Cities_Guid",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Guid_OriginId",
                table: "Persons_Guid",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Guid_AuthorId",
                table: "Posts_Guid",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses_Guid");

            migrationBuilder.DropTable(
                name: "Posts_Guid");

            migrationBuilder.DropTable(
                name: "Cities_Guid");

            migrationBuilder.DropTable(
                name: "Persons_Guid");

            migrationBuilder.DropTable(
                name: "Countries_Guid");
        }
    }
}
