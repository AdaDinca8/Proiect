using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class parte2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoffeShopID",
                table: "CoffeeShopCategorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoffeShopID",
                table: "CoffeeShopCategorie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
