using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Volume = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Milk = table.Column<int>(type: "INTEGER", nullable: false),
                    CocoaPowder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cocoas_Drinks_Id",
                        column: x => x.Id,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Espressos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Coffee = table.Column<int>(type: "INTEGER", nullable: false),
                    SmallCup = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinkId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espressos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Espressos_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cappuccinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Milk = table.Column<int>(type: "INTEGER", nullable: false),
                    MediumCup = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cappuccinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cappuccinos_Espressos_Id",
                        column: x => x.Id,
                        principalTable: "Espressos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rafs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cream = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rafs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rafs_Cappuccinos_Id",
                        column: x => x.Id,
                        principalTable: "Cappuccinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Espressos_DrinkId",
                table: "Espressos",
                column: "DrinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cocoas");

            migrationBuilder.DropTable(
                name: "Rafs");

            migrationBuilder.DropTable(
                name: "Cappuccinos");

            migrationBuilder.DropTable(
                name: "Espressos");

            migrationBuilder.DropTable(
                name: "Drinks");
        }
    }
}
