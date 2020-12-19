using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class skjdhkdfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431cc4f5-6435-49c0-ba13-860b4fd36bcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db7d3c57-f123-4432-8b8e-3eafd74a9130");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Autors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5912cea0-725c-495e-9f43-cd6170665cb9", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "099e19a0-8d66-4dbb-a0ab-b788eeb59b32", "ZKLJ", "User", "USER" });

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
                name: "IX_Autors_Ime",
                table: "Autors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "099e19a0-8d66-4dbb-a0ab-b788eeb59b32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5912cea0-725c-495e-9f43-cd6170665cb9");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Autors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "431cc4f5-6435-49c0-ba13-860b4fd36bcd", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db7d3c57-f123-4432-8b8e-3eafd74a9130", "ZKLJ", "User", "USER" });
        }
    }
}
