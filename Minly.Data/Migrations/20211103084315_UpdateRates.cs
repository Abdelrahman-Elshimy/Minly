using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d1be03e-3bfa-480d-aa71-5c54be869aab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99a464d-4d48-4a94-8564-0ed4df386072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a0eb85-4068-4f94-bfb7-9905fd4d6d39");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "264b6d89-ebb8-43c7-ba28-5a5841520859", "a67d9413-c4b4-4042-aa7a-f13a092f33ac", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97a968b0-bf5d-44f5-878e-ecfad9f93d0d", "2b91863e-84fa-40ce-8f97-98fbc5143a44", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7089c3ba-5c77-4907-8da9-b50e1cdbdeb2", "71e09b16-5725-469f-b453-0872232bed6c", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264b6d89-ebb8-43c7-ba28-5a5841520859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7089c3ba-5c77-4907-8da9-b50e1cdbdeb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97a968b0-bf5d-44f5-878e-ecfad9f93d0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8a0eb85-4068-4f94-bfb7-9905fd4d6d39", "3543eecd-7dfa-41c5-871f-d1480f39f49c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d99a464d-4d48-4a94-8564-0ed4df386072", "c24e544d-5a05-4431-9a98-cc3aaf1b0cab", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d1be03e-3bfa-480d-aa71-5c54be869aab", "bb5204f7-fc69-41d0-9411-2fd21e487a67", "Star", "STAR" });
        }
    }
}
