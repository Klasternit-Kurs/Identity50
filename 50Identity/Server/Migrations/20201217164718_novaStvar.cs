using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class novaStvar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorKnjiga");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31fac436-7caf-4264-9a55-759bd3c5e814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "884fe4cb-53d8-43ad-a2ed-60a86d3a85f9");

            migrationBuilder.CreateTable(
                name: "KnjigaAutors",
                columns: table => new
                {
                    Autor_FK = table.Column<int>(type: "int", nullable: false),
                    Knjiga_FK = table.Column<int>(type: "int", nullable: false),
                    Izdata = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigaAutors", x => new { x.Knjiga_FK, x.Autor_FK });
                    table.ForeignKey(
                        name: "FK_KnjigaAutors_Autors_Autor_FK",
                        column: x => x.Autor_FK,
                        principalTable: "Autors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnjigaAutors_Knjigas_Knjiga_FK",
                        column: x => x.Knjiga_FK,
                        principalTable: "Knjigas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8b71922-6515-43b0-af86-38f470f93445", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a62e054-0f93-4bef-9808-1c8aa4489966", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_KnjigaAutors_Autor_FK",
                table: "KnjigaAutors",
                column: "Autor_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnjigaAutors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a62e054-0f93-4bef-9808-1c8aa4489966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b71922-6515-43b0-af86-38f470f93445");

            migrationBuilder.CreateTable(
                name: "AutorKnjiga",
                columns: table => new
                {
                    AutoriID = table.Column<int>(type: "int", nullable: false),
                    KnjigeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorKnjiga", x => new { x.AutoriID, x.KnjigeID });
                    table.ForeignKey(
                        name: "FK_AutorKnjiga_Autors_AutoriID",
                        column: x => x.AutoriID,
                        principalTable: "Autors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorKnjiga_Knjigas_KnjigeID",
                        column: x => x.KnjigeID,
                        principalTable: "Knjigas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "884fe4cb-53d8-43ad-a2ed-60a86d3a85f9", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31fac436-7caf-4264-9a55-759bd3c5e814", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_AutorKnjiga_KnjigeID",
                table: "AutorKnjiga",
                column: "KnjigeID");
        }
    }
}
