using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAcessories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, ImageUrl, CategoryId)" +
                "VALUES('Relogio PHILIP', 'Relogio Prata', 150.00, 23, 'imageRelogio.jpg',2) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Product");
        }
    }
}
