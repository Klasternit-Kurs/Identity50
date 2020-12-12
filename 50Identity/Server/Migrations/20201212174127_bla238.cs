using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class bla238 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c5dafc-f57b-4610-bc48-8651ffe50269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2210318-fc84-4df4-9a4a-28a9ce3928b7");

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
                keyValue: "042a221f-dd92-4179-963e-9a9a03711330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43424242-5f5e-4054-9f6f-e654e8e4677e");

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
                values: new object[] { "f2210318-fc84-4df4-9a4a-28a9ce3928b7", "ZKLJ", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7c5dafc-f57b-4610-bc48-8651ffe50269", "ZKLJ", "User", "USER" });
        }
    }
}
