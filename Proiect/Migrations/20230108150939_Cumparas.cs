using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    public partial class Cumparas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cumpara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    CoffeeShopID = table.Column<int>(type: "int", nullable: true),
                    DataCumparat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cumpara", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cumpara_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cumpara_CoffeeShop_CoffeeShopID",
                        column: x => x.CoffeeShopID,
                        principalTable: "CoffeeShop",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cumpara_ClientID",
                table: "Cumpara",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cumpara_CoffeeShopID",
                table: "Cumpara",
                column: "CoffeeShopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cumpara");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
