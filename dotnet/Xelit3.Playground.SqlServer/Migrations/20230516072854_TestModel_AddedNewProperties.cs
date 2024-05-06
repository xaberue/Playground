using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModel_AddedNewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Persons_long",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons_long",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Persons_long",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Persons_int",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons_int",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Persons_int",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Persons_Guid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons_Guid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Persons_Guid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Persons_long");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons_long");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Persons_long");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Persons_int");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons_int");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Persons_int");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Persons_Guid");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons_Guid");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Persons_Guid");
        }
    }
}
