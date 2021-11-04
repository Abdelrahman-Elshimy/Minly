using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d5f1719-0235-4517-a871-c71851b8d6bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a119765-45b5-47b4-9f24-efe317883d7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91f2ecb-e55e-49e3-9f7f-ead718d1d24e");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "StarServices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cc25b41-c4ae-4e99-b56c-2c0cd4695034", "6e9b72d6-a5fc-43fd-b8bb-9e5747415896", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5eb6f85b-b77c-4199-a350-8ce57493a08f", "8421f43e-78da-4202-90c8-ac899ce91ad6", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5845d4a-eb9b-44c3-b6db-ec7db01d7583", "34a4c632-bd7e-4a3b-b2cf-cded7e781abb", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eb6f85b-b77c-4199-a350-8ce57493a08f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cc25b41-c4ae-4e99-b56c-2c0cd4695034");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5845d4a-eb9b-44c3-b6db-ec7db01d7583");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "StarServices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d5f1719-0235-4517-a871-c71851b8d6bf", "6ac2f03b-f61e-43d7-bdff-705c97596b30", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a91f2ecb-e55e-49e3-9f7f-ead718d1d24e", "53302413-c3e4-47c8-a575-fb2de369324e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a119765-45b5-47b4-9f24-efe317883d7d", "fdd979be-d720-4eb0-98d9-6d42a597e6fd", "Star", "STAR" });
        }
    }
}
