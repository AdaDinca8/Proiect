using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class CoffeeShopCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeShopCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeShopID = table.Column<int>(type: "int", nullable: false),
                    CoffeeShopID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShopCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeeShopCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeShopCategorie_CoffeeShop_CoffeeShopID",
                        column: x => x.CoffeeShopID,
                        principalTable: "CoffeeShop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeShopCategorie_CategorieID",
                table: "CoffeeShopCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeShopCategorie_CoffeeShopID",
                table: "CoffeeShopCategorie",
                column: "CoffeeShopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeShopCategorie");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
