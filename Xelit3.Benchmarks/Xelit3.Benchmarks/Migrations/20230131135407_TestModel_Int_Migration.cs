using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModelIntMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_int", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    CountryId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_int_Countries_int_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Countries_int",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_int_Countries_int_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Countries_int",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CityId1 = table.Column<int>(type: "int", nullable: false),
                    PersonId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_int_Cities_int_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities_int",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_int_Persons_int_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Persons_int",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_int_Persons_int_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons_int",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_int_CityId1",
                table: "Addresses_int",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_int_PersonId1",
                table: "Addresses_int",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_int_CountryId1",
                table: "Cities_int",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_int_OriginId",
                table: "Persons_int",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_int_AuthorId",
                table: "Posts_int",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses_int");

            migrationBuilder.DropTable(
                name: "Posts_int");

            migrationBuilder.DropTable(
                name: "Cities_int");

            migrationBuilder.DropTable(
                name: "Persons_int");

            migrationBuilder.DropTable(
                name: "Countries_int");
        }
    }
}
