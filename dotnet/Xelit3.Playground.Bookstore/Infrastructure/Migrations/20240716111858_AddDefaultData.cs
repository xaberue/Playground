using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xelit3.Playground.Bookstore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string insertSql = @"
                INSERT INTO Books (Isbn, Title, Author, YearPublished, Price, CreationDate, IsDeleted) VALUES ('ISBN-1', 'Title 1', 'Author 1 TEST', 2020, 5, DATE('now'), 0);
                INSERT INTO Books (Isbn, Title, Author, YearPublished, Price, CreationDate, IsDeleted) VALUES ('ISBN-2', 'Title 2', 'Author 1 TEST', 2018, 15, DATE('now'), 0);
                INSERT INTO Books (Isbn, Title, Author, YearPublished, Price, CreationDate, IsDeleted) VALUES ('ISBN-3', 'Title 3', 'Author 2 TEST', 2021, 10, DATE('now'), 0);
                INSERT INTO Books (Isbn, Title, Author, YearPublished, Price, CreationDate, IsDeleted) VALUES ('ISBN-4', 'Title 4', 'Author 2 TEST', 2007, 12, DATE('now'), 0);
                INSERT INTO Books (Isbn, Title, Author, YearPublished, Price, CreationDate, IsDeleted) VALUES ('ISBN-5', 'Title 5', 'Author 2 TEST', 2010, 10, DATE('now'), 0);

                INSERT INTO Clients (Name, Surname, Address, RegistrationDate, BirthDate, CreationDate, IsDeleted) VALUES ('User1', 'Surname1', 'Address 1 TEEST', DATE('now'), '1980/05/01', DATE('now'), 0);
                INSERT INTO Clients (Name, Surname, Address, RegistrationDate, BirthDate, CreationDate, IsDeleted) VALUES ('User1', 'Surname1', 'Address 1 TEEST', DATE('now'), '2010/05/01', DATE('now'), 0);
            ";

            migrationBuilder.Sql(insertSql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
