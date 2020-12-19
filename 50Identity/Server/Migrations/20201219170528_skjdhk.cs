using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class skjdhk : Migration
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
                keyValue: "4a62e054-0f93-4bef-9808-1c8aa4489966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b71922-6515-43b0-af86-38f470f93445");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Knjigas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Naziv",
                table: "Knjigas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                values: new object[] { "b8b71922-6515-43b0-af86-38f470f93445", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a62e054-0f93-4bef-9808-1c8aa4489966", "ZKLJ", "User", "USER" });

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
    }
}
