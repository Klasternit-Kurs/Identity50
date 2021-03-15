using Microsoft.EntityFrameworkCore.Migrations;

namespace _50Identity.Server.Migrations
{
    public partial class tipFajla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14153c4d-2614-48f2-ab00-032bd2fba868");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9eaeb8b-29ee-4771-b13d-cc6b1f7c5c18");

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Fajls",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fe2d07b-c487-4564-92da-8c72178b4c27", "ZKLJ", "Admin", "ADMIN" },
                    { "88f98619-2b04-4a38-84fa-5be9e718f517", "ZKLJ", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fe2d07b-c487-4564-92da-8c72178b4c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88f98619-2b04-4a38-84fa-5be9e718f517");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Fajls");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14153c4d-2614-48f2-ab00-032bd2fba868", "ZKLJ", "Admin", "ADMIN" },
                    { "a9eaeb8b-29ee-4771-b13d-cc6b1f7c5c18", "ZKLJ", "User", "USER" }
                });
        }
    }
}
