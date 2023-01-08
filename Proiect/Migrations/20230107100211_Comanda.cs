using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Comanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "CoffeeShop",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ComandaID",
                table: "CoffeeShop",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusComanda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeShop_ComandaID",
                table: "CoffeeShop",
                column: "ComandaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeShop_Comanda_ComandaID",
                table: "CoffeeShop",
                column: "ComandaID",
                principalTable: "Comanda",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeShop_Comanda_ComandaID",
                table: "CoffeeShop");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeShop_ComandaID",
                table: "CoffeeShop");

            migrationBuilder.DropColumn(
                name: "ComandaID",
                table: "CoffeeShop");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "CoffeeShop",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
