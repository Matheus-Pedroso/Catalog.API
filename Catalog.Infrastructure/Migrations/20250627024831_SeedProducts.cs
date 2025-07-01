using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, ImageUrl, CategoryId)" +
                "VALUES('Caderno Espiral', 'Caderno Espiral 1000 folhas', 8.50, 5, 'imageCaderno.jpg',3) ");

            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, ImageUrl, CategoryId)" +
                "VALUES('Celular', 'Celular de 500GB', 1599.99, 15, 'imageCelular.jpg',1 )");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Product");
        }
    }
}
