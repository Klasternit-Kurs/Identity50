using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class dgdrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8baaae29-1819-4f2a-8bf3-797c1c7a4bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c985e024-df41-492e-988b-f992589ce5c8");

            migrationBuilder.CreateTable(
                name: "Artikals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Racuns",
                columns: table => new
                {
                    Rbr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuns", x => x.Rbr);
                });

            migrationBuilder.CreateTable(
                name: "RacunArtikal",
                columns: table => new
                {
                    RacunFK = table.Column<int>(type: "int", nullable: false),
                    ArtikalFK = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacunArtikal", x => new { x.ArtikalFK, x.RacunFK });
                    table.ForeignKey(
                        name: "FK_RacunArtikal_Artikals_ArtikalFK",
                        column: x => x.ArtikalFK,
                        principalTable: "Artikals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacunArtikal_Racuns_RacunFK",
                        column: x => x.RacunFK,
                        principalTable: "Racuns",
                        principalColumn: "Rbr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b25734d7-780a-4375-99db-6e979d805180", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9948db2-b894-4d8e-a0f1-fc8cfcf44805", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_RacunArtikal_RacunFK",
                table: "RacunArtikal",
                column: "RacunFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacunArtikal");

            migrationBuilder.DropTable(
                name: "Artikals");

            migrationBuilder.DropTable(
                name: "Racuns");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b25734d7-780a-4375-99db-6e979d805180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9948db2-b894-4d8e-a0f1-fc8cfcf44805");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8baaae29-1819-4f2a-8bf3-797c1c7a4bc2", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c985e024-df41-492e-988b-f992589ce5c8", "ZKLJ", "User", "USER" });
        }
    }
}
