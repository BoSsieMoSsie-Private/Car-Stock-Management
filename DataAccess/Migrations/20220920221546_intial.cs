using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KMS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RetailPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DTCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DTUpdated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.StockItemID);
                });

            migrationBuilder.CreateTable(
                name: "StockAccessory",
                columns: table => new
                {
                    AccessoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StockItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAccessory", x => x.AccessoryID);
                    table.ForeignKey(
                        name: "FK_StockAccessory_StockItem",
                        column: x => x.StockItemID,
                        principalTable: "StockItem",
                        principalColumn: "StockItemID");
                });

            migrationBuilder.CreateTable(
                name: "StockImage",
                columns: table => new
                {
                    StockImageID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StockItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockImage", x => x.StockImageID);
                    table.ForeignKey(
                        name: "fk_StockItem",
                        column: x => x.StockItemID,
                        principalTable: "StockItem",
                        principalColumn: "StockItemID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockAccessory_StockItemID",
                table: "StockAccessory",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_StockImage_StockItemID",
                table: "StockImage",
                column: "StockItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockAccessory");

            migrationBuilder.DropTable(
                name: "StockImage");

            migrationBuilder.DropTable(
                name: "StockItem");
        }
    }
}
