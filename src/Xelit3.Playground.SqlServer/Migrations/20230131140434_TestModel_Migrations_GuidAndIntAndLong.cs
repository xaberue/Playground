﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    /// <inheritdoc />
    public partial class TestModelMigrationsGuidAndIntAndLong : Migration
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
                name: "Countries_long",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_long", x => x.Id);
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
                name: "Cities_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_int_Countries_int_CountryId",
                        column: x => x.CountryId,
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
                name: "Cities_long",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities_long", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_long_Countries_long_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries_long",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons_long",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_long", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_long_Countries_long_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Countries_long",
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

            migrationBuilder.CreateTable(
                name: "Addresses_int",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses_int", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_int_Cities_int_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities_int",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_int_Persons_int_PersonId",
                        column: x => x.PersonId,
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

            migrationBuilder.CreateTable(
                name: "Addresses_long",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses_long", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_long_Cities_long_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities_long",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_long_Persons_long_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons_long",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts_long",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts_long", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_long_Persons_long_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons_long",
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
                name: "IX_Addresses_int_CityId",
                table: "Addresses_int",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_int_PersonId",
                table: "Addresses_int",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_long_CityId",
                table: "Addresses_long",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_long_PersonId",
                table: "Addresses_long",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Guid_CountryId",
                table: "Cities_Guid",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_int_CountryId",
                table: "Cities_int",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_long_CountryId",
                table: "Cities_long",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Guid_OriginId",
                table: "Persons_Guid",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_int_OriginId",
                table: "Persons_int",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_long_OriginId",
                table: "Persons_long",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Guid_AuthorId",
                table: "Posts_Guid",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_int_AuthorId",
                table: "Posts_int",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_long_AuthorId",
                table: "Posts_long",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses_Guid");

            migrationBuilder.DropTable(
                name: "Addresses_int");

            migrationBuilder.DropTable(
                name: "Addresses_long");

            migrationBuilder.DropTable(
                name: "Posts_Guid");

            migrationBuilder.DropTable(
                name: "Posts_int");

            migrationBuilder.DropTable(
                name: "Posts_long");

            migrationBuilder.DropTable(
                name: "Cities_Guid");

            migrationBuilder.DropTable(
                name: "Cities_int");

            migrationBuilder.DropTable(
                name: "Cities_long");

            migrationBuilder.DropTable(
                name: "Persons_Guid");

            migrationBuilder.DropTable(
                name: "Persons_int");

            migrationBuilder.DropTable(
                name: "Persons_long");

            migrationBuilder.DropTable(
                name: "Countries_Guid");

            migrationBuilder.DropTable(
                name: "Countries_int");

            migrationBuilder.DropTable(
                name: "Countries_long");
        }
    }
}
