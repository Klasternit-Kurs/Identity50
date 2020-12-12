using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class dgdrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas");

            migrationBuilder.DropIndex(
                name: "IX_Autors_Ime",
                table: "Autors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "042a221f-dd92-4179-963e-9a9a03711330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43424242-5f5e-4054-9f6f-e654e8e4677e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "884fe4cb-53d8-43ad-a2ed-60a86d3a85f9", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31fac436-7caf-4264-9a55-759bd3c5e814", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas",
                column: "Naziv",
                unique: true,
                filter: "[Naziv] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Autors_Ime",
                table: "Autors",
                column: "Ime",
                unique: true,
                filter: "[Ime] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas");

            migrationBuilder.DropIndex(
                name: "IX_Autors_Ime",
                table: "Autors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31fac436-7caf-4264-9a55-759bd3c5e814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "884fe4cb-53d8-43ad-a2ed-60a86d3a85f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "042a221f-dd92-4179-963e-9a9a03711330", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43424242-5f5e-4054-9f6f-e654e8e4677e", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas",
                column: "Naziv");

            migrationBuilder.CreateIndex(
                name: "IX_Autors_Ime",
                table: "Autors",
                column: "Ime");
        }
    }
}
