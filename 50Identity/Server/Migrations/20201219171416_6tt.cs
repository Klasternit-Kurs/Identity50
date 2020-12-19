using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class _6tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "099e19a0-8d66-4dbb-a0ab-b788eeb59b32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5912cea0-725c-495e-9f43-cd6170665cb9");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Knjigas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f820999b-696a-4a66-9ee5-7bc7e90faebf", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebc4114c-cd59-49c6-b8c1-38ac03de6fc1", "ZKLJ", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas",
                column: "Naziv",
                unique: true,
                filter: "[Naziv] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Knjigas_Naziv",
                table: "Knjigas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebc4114c-cd59-49c6-b8c1-38ac03de6fc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f820999b-696a-4a66-9ee5-7bc7e90faebf");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Knjigas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5912cea0-725c-495e-9f43-cd6170665cb9", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "099e19a0-8d66-4dbb-a0ab-b788eeb59b32", "ZKLJ", "User", "USER" });
        }
    }
}
